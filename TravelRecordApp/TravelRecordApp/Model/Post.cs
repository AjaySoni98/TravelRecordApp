using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        private int id;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            { 
                id = value;
                OnPropertyChanged();
            }
        }

        private string experience;

        [MaxLength(250)]
        public string Experience
        {
            get 
            {
                return experience;
            }
            set
            { 
                experience = value;
                OnPropertyChanged();
            }
        }

        private string venuename;

        public string VenueName
        {
            get
            {
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                return myTI.ToTitleCase(venuename);
            }
            set 
            { 
                venuename = value;
                OnPropertyChanged();
            }
        }

        private string categoryid;

        public string CategoryId
        {
            get { return categoryid; }
            set 
            { 
                categoryid = value;
                OnPropertyChanged();
            }
        }

        private string categoryname;

        public string CategoryName
        {
            get { return categoryname; }
            set
            {
                categoryname = value;
                OnPropertyChanged();
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            { 
                address = value;
                OnPropertyChanged();
            }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set 
            { 
                latitude = value;
                OnPropertyChanged();
            }
        }

        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set 
            { 
                longitude = value;
                OnPropertyChanged();
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set 
            { 
                distance = value;
                OnPropertyChanged();
            }
        }

        private int userid;

        public int UserID
        {
            get { return userid; }
            set 
            { 
                userid = value;
                OnPropertyChanged();
            }
        }

        private Venue venue;

        [Ignore]
        public Venue Venue
        {
            get { return venue; }
            set 
            { 
                venue = value;

                if (venue.categories != null)
                {
                    var firstCategory = venue.categories.FirstOrDefault();

                    if (firstCategory != null)
                    {
                        CategoryId = firstCategory.id;
                        CategoryName = firstCategory.name;
                    }
                }

                if (venue.location != null)
                {
                    Address = venue.location.address;
                    Distance = venue.location.distance;
                    Latitude = venue.location.lat;
                    Longitude = venue.location.lng;
                }
                
                VenueName = venue.name;
                UserID = App.gUser.Id;

                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public static bool InsertPost(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);
                if (rows>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<Post> GetPosts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                return conn.Table<Post>().Where(p => p.UserID == App.gUser.Id).ToList();
            }
        }

        public static Dictionary<string, int> PostCategoriesCount(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var car in categories)
            {
                var count = (from p in posts
                             where p.CategoryName == car
                             select p).ToList().Count();

                categoriesCount.Add(car, count);
            }
            return categoriesCount;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

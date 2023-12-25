using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class NewTravelVM : INotifyPropertyChanged
    {
        public PostCommand PostCommand { get; set; }

        private Venue venue;

        public Venue Venue
        {
            get { return venue; }
            set 
            { 
                venue = value;
                Post = new Post()
                {
                    Experience = this.Experience,
                    Venue = this.venue
                };
                OnPropertyChanged();
            }
        }

        private Post post;

        public Post Post
        {
            get { return post; }
            set 
            { 
                post = value;
                OnPropertyChanged();
            }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set 
            { 
                experience = value;
                Post = new Post()
                {
                    Experience = this.Experience,
                    Venue = this.venue
                };
                OnPropertyChanged();
            }
        }


        public NewTravelVM()
        {
            PostCommand = new PostCommand(this);
            Venue = new Venue();
            Post = new Post();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async void PublishPost(Post post)
        {
            if (Post.InsertPost(post) == true)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Experience successfully inserted", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
            }
        }
    }
}

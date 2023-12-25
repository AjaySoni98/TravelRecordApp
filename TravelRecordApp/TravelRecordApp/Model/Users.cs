using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TravelRecordApp.Model 
{
    public class Users : INotifyPropertyChanged
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

        private string email;

        [MaxLength(256)]
        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                OnPropertyChanged();
            }
        }

        private string password;

        [MaxLength(256)]
        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                OnPropertyChanged();
            }
        }

        private string confpassword;

        [MaxLength(256)]
        public string ConfirmPassword
        {
            get { return confpassword; }
            set
            {
                confpassword = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static Users GetUsers(string email)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var res = conn.Table<Users>().Where(u => u.Email == email).ToList();
                if (res.Count > 0)
                {
                    return res[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public static bool Login(string email, string pass)
        {
            Users usersR = null;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                return false;
            }
            string retrievedPass = null;

            usersR = GetUsers(email);

            if (usersR == null)
            {
                return false;
            }
            else
            {
                retrievedPass = usersR.Password;
                if (pass != retrievedPass)
                {
                    return false;
                }
                else
                {
                    App.gUser = usersR;
                    return true;
                }
            }
        }

        public static bool Register(Users user)
        {
            var email = user.Email;
            var pass = user.Password;
            var confirmpass = user.ConfirmPassword;
            if (pass == confirmpass && !string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(confirmpass) && !string.IsNullOrEmpty(email))
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    var usersTable = conn.Table<Users>().ToList();

                    if (usersTable.Where(u => u.Email == email).ToList().Count == 0)
                    {
                        conn.CreateTable<Users>();
                        int rows = conn.Insert(user);
                        if (rows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
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

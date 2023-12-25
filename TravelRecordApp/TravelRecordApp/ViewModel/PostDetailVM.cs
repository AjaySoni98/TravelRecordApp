using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class PostDetailVM
    {
        public UpdateCommand UpdateCommand { get; set; }

        public DeleteCommand DeleteCommand { get; set; }

        private Post post;

        public Post Post
        {
            get { return post; }
            set 
            { 
                post = value; 
            }
        }

        public PostDetailVM()
        {
            UpdateCommand = new UpdateCommand(this);
            DeleteCommand = new DeleteCommand(this);
        }

        public async void Update()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(Post);

                if (rows > 0)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Experience successfully updated", "Ok");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be updated", "Ok");
                }
            }
        }

        public async void Delete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(Post);

                if (rows > 0)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Experience successfully deleted", "Ok");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
                }
            }
        }
    }
}

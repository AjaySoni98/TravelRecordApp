using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        ProfilePageVM profilePageVM;
        public ProfilePage()
        {
            InitializeComponent();
            profilePageVM = new ProfilePageVM();
            BindingContext = profilePageVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
            var postTable = Post.GetPosts();

            categoriesListView.ItemsSource = Post.PostCategoriesCount(postTable);

            postCountLabel.Text = postTable.Count.ToString();
        }
    }
}
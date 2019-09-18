using AnxietyNZ.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnxietyNZ
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();



        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //READ FROM THE DATABASE
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<contributor_test>();

                //TRANSFORM TABLE INTO A LIST, READY TO DISPLAY
                var contributors = conn.Table<contributor_test>().ToList();
                contributorListView.ItemsSource = contributors;
            };
        }

        private void navigate_newContributor(object sender, EventArgs e)
        {
            Navigation.PushAsync(new newContributorPage(null));
        }

        private async void Edit_Contributor(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(new newContributorPage(btn.BindingContext));
        }

        private void contributor_detail_navigate(object sender, ItemTappedEventArgs e)
        {
            var contributor_details = e.Item as contributor_test;
            var contributor_detail_id = contributor_details.contributor_id.ToString();
            Navigation.PushAsync(new contributorDetailPage(contributor_detail_id, contributor_details.contributor_name, contributor_details.contributor_phone_number, contributor_details.contributor_email, contributor_details.contributor_address));



            //string contributor_id, string contributor_name, string contributor_phone_number, string contributor_email, string contributor_address
        }

        private void Delete_Contributor(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection conn = (new SQLite.SQLiteConnection(App.DB_PATH)))
            {
                var mi = sender as MenuItem;
                var item = mi.CommandParameter as contributor_test;
                conn.Delete(item);
            }
        }

        private void To_Overview(object sender, EventArgs e)
        {
            Navigation.PushAsync(new master.MasterDetailPage1());
        }
    }
}

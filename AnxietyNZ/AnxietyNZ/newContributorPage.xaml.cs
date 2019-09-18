using AnxietyNZ.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnxietyNZ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class newContributorPage : ContentPage
    {

        public newContributorPage(object current_contributor)
        {
            InitializeComponent();
            ContributorInfo.BindingContext = current_contributor;
            

        }

        private void Save_Contributor(object sender, EventArgs e)
        {
            //CREATES A NEW INSTANCE OF THE CONTRIBUTOR (CURRENTLY FOR TESTING PURPOSES)
            contributor_test contributor = new contributor_test()
            {
                contributor_name = name_entry.Text,
                contributor_address = address_entry.Text,
                contributor_email = email_entry.Text,
                contributor_phone_number = ph_number_entry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                if (CheckContributor(contributor))
                {
                    conn.CreateTable<contributor_test>();
                    conn.Insert(contributor);

                    DisplayAlert("Success!", "Contributor Inserted '" + contributor.contributor_name + "' Into the database!", "Confirm");

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Sorry!", "There was an error inserting this contributor into the database!", "Okay");
                }
            }
        }

        private bool CheckContributor(contributor_test contributor)
        {
            foreach (PropertyInfo contributee in contributor.GetType().GetProperties())
            {
                if (contributee.PropertyType == typeof(string))
                {
                    string value = (string)contributee.GetValue(contributor);
                    if (string.IsNullOrEmpty(value))
                        return false;
                }
            }
            return true;
        }

        private void Edit_Contributor(object sender, EventArgs e)
        {
            var c_id = update_id.Text;

            

            //CREATES A NEW INSTANCE OF THE CONTRIBUTOR
            contributor_test contributor = new contributor_test()
            {
                contributor_name = name_entry.Text,
                contributor_address = address_entry.Text,
                contributor_email = email_entry.Text,
                contributor_phone_number = ph_number_entry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                if (CheckContributor(contributor))
                {
                    conn.CreateTable<contributor_test>();
                    conn.Insert(contributor);

                    DisplayAlert("Success!", "You have modified " + name_entry.Text + ". ", "Confirm");

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Sorry!", "There was an error inserting this contributor into the database!", "Okay");
                }
            }


            //DELETE CURRENT CONTRIBUTOR
            using (SQLite.SQLiteConnection conn = (new SQLite.SQLiteConnection(App.DB_PATH)))
            {
                conn.Query<contributor_test>(
                    "DELETE FROM contributor_test WHERE contributor_id = " + c_id);
            }

        }
    }
}

// ("UPDATE contributor_test SET " + update_field + " =  ' " + update_value + " ' WHERE contributor_id = " + contributor_id_update);
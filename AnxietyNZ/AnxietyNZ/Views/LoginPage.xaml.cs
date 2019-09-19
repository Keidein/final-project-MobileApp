using AnxietyNZ.Models;
using AnxietyNZ.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnxietyNZ.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();

            LoginIcon.Source = ImageSource.FromFile("anxietynz.png");
        }

        void Init()
        {
            
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;

            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            if (Entry_Username.Text == null )
            {
                await DisplayAlert("Login", "Login incorrect, empty username or password", "Ok");
            } else if (Entry_Password.Text == null)
            {
                await DisplayAlert("Login", "Login incorrect, empty username or password", "Ok");
            } else {
                User user = new User(Entry_Username.Text, Entry_Password.Text);
                if (user.CheckInformation())
                {
                    await DisplayAlert("Login", "Login Success", "Ok");
                    // var result = await App.RestService.Login(user);
                    var result = new Token();
                    if (result != null)
                    {
                        //App.UserDatabase.SaveUser(user);
                        //App.TokenDatabase.SaveToken(result);
                        if (Device.OS == TargetPlatform.Android)
                        {
                            Application.Current.MainPage = new NavigationPage(new master.MasterDetailPage1());
                        }
                        else if (Device.OS == TargetPlatform.iOS)
                        {
                            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                        }
                    }

                }
                else
                {
                    await DisplayAlert("Login", "Login incorrect, empty username or password", "Ok");
                }
            }

            
        }
    }
}
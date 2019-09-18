using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnxietyNZ.Views;
using AnxietyNZ.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AnxietyNZ
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;

        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        static RestService restService;

        public App(string db_path)
        {
            InitializeComponent();

            DB_PATH = db_path;

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        public static UserDatabaseController UserDatabase
        {
            get
            {
                if(userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if(tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }

        public static RestService RestService
        {
            get
            {
                if(restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }
    }
}

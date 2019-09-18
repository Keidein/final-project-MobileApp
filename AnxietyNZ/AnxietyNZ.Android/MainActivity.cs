using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace AnxietyNZ.Droid
{
    [Activity(Label = "AnxietyNZ", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);


            //CREATES THE DATABASE FILE
            string fileName = "contributors_db.sqlite";
            //LOCATES THE DATABASE FILE IN THE ANDROID APPLICATON
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string full_path = Path.Combine(fileLocation, fileName);

            
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //SENDS THE DATABASE FILE TO THE APP CLASS
            LoadApplication(new App(full_path));
        }
    }
}
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using photosNews.Views;
using photosNews.Data;
using System.IO;

namespace photosNews
{
    public partial class App : Application
    {
        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new login());
        }

        public static SQLiteHelper SQliteDB
        {
            get
            {
                if(db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData),"usuarios.db3"));
                }
                return db;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

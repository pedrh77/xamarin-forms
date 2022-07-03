using SqlLite.Helpers;
using System;
using System.IO;
using Xamarin.Forms;

namespace SqlLite
{
    public partial class App : Application
    {
        static SqLiteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static SqLiteHelper SQLiteDb
        {
            get
            {
                if (db == null)
                { db = new SqLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BDContato.db3")); }
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

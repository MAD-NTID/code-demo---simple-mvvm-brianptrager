using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleUserDatabase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new UsersListPage();
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

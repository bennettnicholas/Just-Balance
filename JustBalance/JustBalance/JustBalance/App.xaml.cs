using JustBalance.Views;
using System;
using Xamarin.Forms;
using JustBalance.Models;
using Xamarin.Forms.Xaml;

namespace JustBalance
{
    public partial class App : Application
    {
        public static string UserName = "Nick";
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            
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

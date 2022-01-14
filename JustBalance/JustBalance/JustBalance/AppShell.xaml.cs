using JustBalance.ViewModels;
using JustBalance.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JustBalance
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(AddTransaction), typeof(AddTransaction));
            Routing.RegisterRoute(nameof(ViewTransaction), typeof(ViewTransaction));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AboutPage");
        }
    }
}

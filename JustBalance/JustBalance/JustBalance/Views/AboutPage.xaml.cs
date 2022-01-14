using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JustBalance.Models;
using JustBalance;

namespace JustBalance.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        void SubmitButtonOnClicked(object sender, EventArgs args)
        {
            App.UserName = UserNameText.Text;
        }
    }
}
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

        void LeftButtonClicked(object sender, EventArgs args)
        {
            App.UserName = leftButton.Text;
            leftButton.BackgroundColor = Color.Black;
            rightButton.BackgroundColor = Color.LightGray;
        }

        void RightButtonClicked(object sender, EventArgs args)
        {
            App.UserName = rightButton.Text;
            rightButton.BackgroundColor = Color.Black;
            leftButton.BackgroundColor = Color.LightGray;
        }
    }
}
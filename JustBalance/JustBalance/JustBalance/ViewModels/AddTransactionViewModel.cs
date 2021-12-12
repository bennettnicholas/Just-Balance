using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JustBalance.ViewModels
{
    public class AddTransactionViewModel : BaseViewModel
    {
        public AddTransactionViewModel()
        {
            Title = "New Transaction";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://google.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
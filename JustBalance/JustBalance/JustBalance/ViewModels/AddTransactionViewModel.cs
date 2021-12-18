using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace JustBalance.ViewModels
{
    public class AddTransactionViewModel : BaseViewModel
    {
        public AddTransactionViewModel()
        {
            Title = "New Transaction";
        }
    }

}
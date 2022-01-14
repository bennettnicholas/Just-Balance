using JustBalance.Models;
using System;
using Xamarin.Forms;
using MongoDB.Driver;

namespace JustBalance.Views
{
    public partial class ViewTransaction : ContentPage
    {
        public ViewTransaction()
        {
            Title = "Ledger";
            InitializeComponent();
        }

        void getTransaction(object sender, EventArgs args)
        {
            double sum = 0;
            MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb://application:HelloWorld@justbalance-shard-00-00.5omg9.mongodb.net:27017,justbalance-shard-00-01.5omg9.mongodb.net:27017,justbalance-shard-00-02.5omg9.mongodb.net:27017/JustBalance?ssl=true&replicaSet=atlas-cz5mx5-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("JustBalance");

            var collection = database.GetCollection<Transaction>("Transactions");

            var builder = Builders<Transaction>.Filter;
            var filter = builder.Eq("lender_name", App.UserName);
            var entriesItems = collection.Find(filter).ToList();

            var builder2 = Builders<Transaction>.Filter;
            var filter2 = builder2.Eq("borrower_name", App.UserName);
            var entriesItems2 = collection.Find(filter2).ToList();

            foreach (Transaction Sum in entriesItems)
            {
                if (Sum.LenderName == App.UserName)
                {
                    sum += Sum.Cost;
                }
                else if (Sum.LenderName != App.UserName)
                {
                    sum -= Sum.Cost;
                }
            }
            foreach (Transaction Sum in entriesItems2)
            {
                if (Sum.LenderName != App.UserName)
                {
                    sum -= Sum.Cost;
                }
                else if (Sum.LenderName == App.UserName)
                {
                    sum += Sum.Cost;
                }
            }
            ledgerSum.Text = sum.ToString();
            EntriesLV.ItemsSource = entriesItems;
            EntriesLV2.ItemsSource = entriesItems2;


        }
    }
}
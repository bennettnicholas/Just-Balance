using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MongoDB.Bson;
using MongoDB.Driver;

namespace JustBalance.Views
{
    public partial class AddTransaction : ContentPage
    {
        public AddTransaction()
        {
            InitializeComponent();
        }
        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            
        }
        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
        
        }

        void OnButtoneClick(object sender, EventArgs args)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://application:HelloWorld@justbalance-shard-00-00.5omg9.mongodb.net:27017,justbalance-shard-00-01.5omg9.mongodb.net:27017,justbalance-shard-00-02.5omg9.mongodb.net:27017/JustBalance?ssl=true&replicaSet=atlas-cz5mx5-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("JustBalance");
            var collection = database.GetCollection<BsonDocument>("Transactions");
            var cost = 4.20;

            var document = new BsonDocument {
                { "lendor_id", 1 },
                { "borrower_id", 2 },
                { "title", "SHHHHH TESTING" },
                { "description", "I SAID SHUT THE FUCK UP OH MY GOD SHHHHHH" },
                { "cost", cost },
                { "date", DateTime.Now},
                { "approved", false },
            };

            collection.InsertOne(document);
        }
    }
}
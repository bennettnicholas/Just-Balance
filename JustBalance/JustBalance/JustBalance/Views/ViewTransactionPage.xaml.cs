using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JustBalance.Views
{
    public partial class ViewTransaction : ContentPage
    {
        public ViewTransaction()
        {
            Title = "Ledger";
            InitializeComponent();
        }

        public class Transaction
        {
            public Object Id { get; set; }
            [BsonElement("lendor_id")]
            public Int32 LendorID { get; set; }
            [BsonElement("borrower_id")]
            public Int32 BorrowerID { get; set; }
            [BsonElement("title")]
            public String Title { get; set; }
            [BsonElement("description")]
            public String Description { get; set; }
            [BsonElement("cost")]
            public Double Cost { get; set; }
            [BsonElement("date")]
            public DateTime Date { get; set; }
            [BsonElement("approved")]
            public Boolean Approved { get; set; }

        }

        async void OnButtonClick(object sender, EventArgs args)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://application:HelloWorld@justbalance-shard-00-00.5omg9.mongodb.net:27017,justbalance-shard-00-01.5omg9.mongodb.net:27017,justbalance-shard-00-02.5omg9.mongodb.net:27017/JustBalance?ssl=true&replicaSet=atlas-cz5mx5-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("JustBalance");
            var collection = database.GetCollection<Transaction>("Transactions");
            var builder = Builders<Transaction>.Filter;
            var filter = builder.Eq("lendor_id", 1);
            filter = filter & builder.Eq("borrower_id", 2);
            var @event = collection.Find(filter).ToList();

            lenderId.Text = @event[0].LendorID.ToString();
            borrowerId.Text = @event[0].BorrowerID.ToString();
            title.Text = @event[0].Title.ToString();
            description.Text = @event[0].Description.ToString();
            cost.Text = @event[0].Cost.ToString();
            date.Text = @event[0].Date.ToString();
            approved.Text = @event[0].Approved.ToString();
        }
    }
}
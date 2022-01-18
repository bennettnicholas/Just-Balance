using System;
using Xamarin.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace JustBalance.Views
{
    public partial class AddTransaction : ContentPage
    {
        public string borrower_name;
        public string lender_name;
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

        void SubmitTransaction(object sender, EventArgs args)
        {
            MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb://application:HelloWorld@justbalance-shard-00-00.5omg9.mongodb.net:27017,justbalance-shard-00-01.5omg9.mongodb.net:27017,justbalance-shard-00-02.5omg9.mongodb.net:27017/JustBalance?ssl=true&replicaSet=atlas-cz5mx5-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("JustBalance");
            var collection = database.GetCollection<BsonDocument>("Transactions");
            var cost = addCost.Text;
            var title = addTitle.Text;
            var description = addDescription.Text;
            var date = startDatePicker.Date;

            var document = new BsonDocument {
                { "lender_id", 1 },
                { "borrower_id", 2 },
                { "borrower_name", borrower_name },
                { "lender_name", lender_name },
                { "title", title },
                { "description", description },
                { "cost", cost },
                { "date", date },
                { "approved", false },
                { "date_added", DateTime.Now }
            };

            collection.InsertOne(document);

            rightButton.BackgroundColor = Color.LightGray;
            leftButton.BackgroundColor = Color.LightGray;
            addCost.Text = "";
            addTitle.Text = "";
            addDescription.Text = "";
            startDatePicker.Date = DateTime.Today;
        }
        void LeftButtonClicked(object sender, EventArgs args)
        {
            borrower_name = leftButton.Text;
            lender_name = rightButton.Text;
            leftButton.BackgroundColor = Color.Black;
            rightButton.BackgroundColor = Color.LightGray;
        }

        void RightButtonClicked(object sender, EventArgs args)
        {
            borrower_name = rightButton.Text;
            lender_name = leftButton.Text;
            rightButton.BackgroundColor = Color.Black;
            leftButton.BackgroundColor = Color.LightGray;
        }
    }
}
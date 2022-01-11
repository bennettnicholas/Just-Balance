using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JustBalance.Models
{
    public class Transaction
    {
        public Object Id { get; set; }

        [BsonElement("lender_id")]
        public int LenderID { get; set; }
        [BsonElement("borrower_id")]
        public int BorrowerID { get; set; }
        [BsonElement("borrower_name")]
        public string BorrowerName { get; set; }
        [BsonElement("lender_name")]
        public string LenderName { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("cost")]
        public double Cost { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("approved")]
        public bool Approved { get; set; }
        [BsonElement("date_added")]
        public DateTime DateAdded { get; set; }

    }
}
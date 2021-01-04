﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiProduct.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string ProductCode { get; set; }
        
        public string ProductName { get; set; }
        
        public decimal Price { get; set; }
    }
}
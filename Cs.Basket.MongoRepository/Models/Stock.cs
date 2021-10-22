using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.MongoRepository.Models
{
    public class Stock
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public Guid ProductComponentId { get; set; }
        public int Quantity { get; set; }
    }
}

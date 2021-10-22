using Cs.Basket.Core.Enums;
using Cs.Basket.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cs.Basket.MongoRepository.Models
{
    public class ProductComposite
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public Guid ProductCompositeId { get; set; }
        public ICollection<ProductComponentQuantityModel> ProductComponents;
        public string Name { get; set; }
        public double Price { get; set; }
    }
}

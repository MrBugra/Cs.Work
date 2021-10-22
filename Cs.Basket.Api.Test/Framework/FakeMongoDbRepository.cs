using Cs.Basket.Core.Enums;
using Cs.Basket.Core.Mongo;
using Cs.Basket.Model;
using Cs.Basket.MongoRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cs.Basket.Api.Test.Framework
{
    public class FakeMongoDbRepository : IMongoRepository
    {
        private Dictionary<Type, object> dataDictionary = new Dictionary<Type, object>();
        public FakeMongoDbRepository()
        {
            dataDictionary.Add(typeof(Cs.Basket.MongoRepository.Models.ProductComposite), MoqDocuments.ProductComposites);
            dataDictionary.Add(typeof(Cs.Basket.MongoRepository.Models.Stock), MoqDocuments.Stocks);
        }
        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> expression, string collectionName = null) where T : class, new()
        {
            
            var data = dataDictionary[typeof(T)];
            IEnumerable<T> list = (IEnumerable<T>)data;
            Func<T, bool> func = expression.Compile();
            Predicate<T> pred = t => func(t);
            return list.Where(func.Invoke).FirstOrDefault();            
        }

        public Task InsertOneAsync<T>(T item, string collectionName = null) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> SearchAsync<T>(Expression<Func<T, bool>> expression, int skip, int limit, string collectionName = null) where T : class, new()
        {
            var data = dataDictionary[typeof(T)];
            IEnumerable<T> list = (IEnumerable<T>)data;
            Func<T, bool> func = expression.Compile();
            Predicate<T> pred = t => func(t);
            return list.Where(func.Invoke).ToList();
        }

        public async Task UpdateOneAsync<T>(Expression<Func<T, bool>> expression, T item, string collectionName = null) where T : class, new()
        {
            var data = dataDictionary[typeof(T)];
            IEnumerable<T> list = (IEnumerable<T>)data;
            Func<T, bool> func = expression.Compile();
            Predicate<T> pred = t => func(t);
            var updatedItem = list.Where(func.Invoke).FirstOrDefault();
            updatedItem = item;            
        }
    }
    
}
public class MoqDocuments
{
    public static List<Cs.Basket.MongoRepository.Models.ProductComposite> ProductComposites = new List<Cs.Basket.MongoRepository.Models.ProductComposite> {
    new Cs.Basket.MongoRepository.Models.ProductComposite{
    Name = "Kişiye Özel Tutkulu Düşler Kek Buketi",
    Price = 100 ,
    ProductCompositeId = Guid.Parse("9029dcf4-18e5-4976-990d-b03ae729cf8c"),
    ProductComponents = new List<ProductComponentQuantityModel>{
    new ProductComponentQuantityModel{
    Component = new ProductComponent
    {
         ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b451"),
         ProductComponentSpecification = ProductComponentSpecificationEnum.BonnyFood,
         Name = "Kırmızı Büyük Boy Kalp Kurabiye"
    },
    Quantity = 10},
    new ProductComponentQuantityModel{
    Component = new ProductComponent
    {
         ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b452"),
         ProductComponentSpecification = ProductComponentSpecificationEnum.BonnyFood,
         Name = "Kırmızı Büyük Boy Kalp Cikolata"
    },
    Quantity = 10}  
    }
    },
    new Cs.Basket.MongoRepository.Models.ProductComposite{
    Name = "Mutluluk Masalı Lilyum ve Kırmızı Gül Aranjmanı",
    Price = 99 ,
    ProductCompositeId = Guid.Parse("937360b7-35f7-4f1d-8dc4-ce352f14b883"),
    ProductComponents = new List<ProductComponentQuantityModel>{
    new ProductComponentQuantityModel{
    Component = new ProductComponent
    {
         ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b453"),
         ProductComponentSpecification = ProductComponentSpecificationEnum.Flower,
         Name = "Kırmızı Büyük Boy Kalp Kurabiye"
    },
    Quantity = 10},
    new ProductComponentQuantityModel{
    Component = new ProductComponent
    {
         ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b454"),
         ProductComponentSpecification = ProductComponentSpecificationEnum.Flower,
         Name = "Kırmızı Büyük Boy Kalp Cikolata"
    },
    Quantity = 10}
    }
    },
    new Cs.Basket.MongoRepository.Models.ProductComposite{
    Name = "Mutluluk Masalı Lilyum ve Kırmızı Gül Aranjmanı Aile Boyu",
    Price = 100000 ,
    ProductCompositeId = Guid.Parse("937360b7-35f7-4f1d-8dc4-ce352f14b884"),
    ProductComponents = new List<ProductComponentQuantityModel>{
    new ProductComponentQuantityModel{
    Component = new ProductComponent
    {
         ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b453"),
         ProductComponentSpecification = ProductComponentSpecificationEnum.Flower,
         Name = "Kırmızı Büyük Boy Kalp Kurabiye"
    },
    Quantity = 150},
    new ProductComponentQuantityModel{
    Component = new ProductComponent
    {
         ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b454"),
         ProductComponentSpecification = ProductComponentSpecificationEnum.Flower,
         Name = "Kırmızı Büyük Boy Kalp Cikolata"
    },
    Quantity = 150}
    }
    }
    };
    public static List<Cs.Basket.MongoRepository.Models.Stock> Stocks = new List<Cs.Basket.MongoRepository.Models.Stock>
    {
        new Stock{
        ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b451"),
        Quantity = 100
        },
        new Stock{
        ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b452"),
        Quantity = 100
        },
        new Stock{
        ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b453"),
        Quantity = 100
        },
        new Stock{
        ProductComponentId = Guid.Parse("39664f0b-fbbe-4502-aa05-16f3ef07b454"),
        Quantity = 100
        },
    };
}

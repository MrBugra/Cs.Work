using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cs.Basket.Core.Mongo
{
    public interface IMongoRepository
    {
        Task<List<T>> SearchAsync<T>(Expression<Func<T, bool>> expression, int skip, int limit, string collectionName = null) where T : class,new();
        Task<T> GetAsync<T>(Expression<Func<T, bool>> expression, string collectionName = null) where T : class,new();
        Task InsertOneAsync<T>(T item, string collectionName = null) where T : class,new();
        Task UpdateOneAsync<T>(Expression<Func<T, bool>> expression,T item,  string collectionName = null) where T : class,new();
    }
}

using Cs.Basket.Core.AppSettingsConfigration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Cs.Basket.Core.Mongo
{
    internal class MongoRepository : IMongoRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        public MongoRepository(IOptions<MongoAppConfigration> option)
        {
            var mongoUrlBuilder = new MongoUrlBuilder(option.Value.ConnectionString);
            var settings = MongoClientSettings.FromUrl(mongoUrlBuilder.ToMongoUrl());
            _client = new MongoClient(settings);
            _database = _client.GetDatabase(mongoUrlBuilder.DatabaseName);
        }
        private IMongoCollection<T> Collection<T>(string collectionName)
        => _database.GetCollection<T>(collectionName ?? typeof(T).Name);
        public async Task<List<T>> SearchAsync<T>(Expression<Func<T, bool>> expression, int skip, int limit, string collectionName = null) where T : class, new()
        => await Collection<T>(collectionName).Find(expression).Skip(skip).Limit(limit).ToListAsync();

        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> expression, string collectionName = null) where T : class, new()
        => await Collection<T>(collectionName ?? typeof(T).Name).Find(expression).FirstOrDefaultAsync();

        public async Task InsertOneAsync<T>(T item, string collectionName = null) where T : class, new()
        => await Collection<T>(collectionName ?? typeof(T).Name).InsertOneAsync(item);

        public async Task UpdateOneAsync<T>(Expression<Func<T, bool>> expression, T item, string collectionName = null) where T : class, new()
        => await Collection<T>(collectionName ?? typeof(T).Name).ReplaceOneAsync(expression, item);
    }
}

using AutoMapper;
using Cs.Basket.Api.Mapper;
using Cs.Basket.Api.Test.Framework;
using Cs.Basket.Core;
using Cs.Basket.Core.AppSettingsConfigration;
using Cs.Basket.Core.Caching;
using Cs.Basket.Core.Mongo;
using Cs.Basket.Service;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cs.Basket.Api.Test
{
    public sealed class TestFixture
    {
        private static readonly Lazy<TestFixture> lazy = new Lazy<TestFixture>(() => new TestFixture());
        private readonly ServiceCollection serviceCollection;
        private readonly ServiceProvider serviceProvider;
        private TestFixture()
        {
            serviceCollection = new ServiceCollection();
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Testing.json").Build();
            serviceCollection.AddBasketServiceDependencies(config);
            //serviceCollection.AddCoreDependencies(config);
            serviceCollection.AddMediatr();
            
            serviceCollection.AddSingleton<IMapper>(s => (new MapperConfiguration
            (c => {
                c.AddProfile<RequestMapperProfile>();
            })).CreateMapper());
            #region FakeFrameWork
            serviceCollection.Configure<CacheAppConfigration>(config.GetSection("CacheSettings"));
            serviceCollection.AddEasyCaching(option => {
                option.UseInMemory(config, config.GetSection("CacheSettings").GetSection("InstanceName").Value);
            });
            serviceCollection.AddScoped<ICacheManager, CacheManager>();
            serviceCollection.AddScoped<IMongoRepository, FakeMongoDbRepository>();
            #endregion
            serviceProvider = serviceCollection.BuildServiceProvider();
        }
        public static TestFixture Instance => lazy.Value;

        public T GetRequiredService<T>()
        {
            return serviceProvider.GetRequiredService<T>();
        }
    }
}

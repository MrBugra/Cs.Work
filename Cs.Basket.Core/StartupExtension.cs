using Cs.Basket.Core.AppSettingsConfigration;
using Cs.Basket.Core.Caching;
using Cs.Basket.Core.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Cs.Basket.Core.Enums;

namespace Cs.Basket.Core
{
    public static class StartupExtension
    {       

        public static void AddCoreDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CacheAppConfigration>(configuration.GetSection("CacheSettings"));
            services.AddEasyCaching(option => {
                switch ((CacheProvider)Convert.ToInt32(configuration.GetSection("CacheSettings").GetSection("Provider").Value))
                {
                    case CacheProvider.Redis:
                        option.UseRedis(configuration,
                            configuration.GetSection("CacheSettings").GetSection("InstanceName").Value);
                        break;
                    case CacheProvider.InMemory:
                        option.UseInMemory(configuration,
                            configuration.GetSection("CacheSettings").GetSection("InstanceName").Value);
                        break;
                    default: throw new NotSupportedException("cache provider is not supported!");
                }
            });
            services.AddScoped<ICacheManager, CacheManager>();
            services.Configure<MongoAppConfigration>(configuration.GetSection("Mongo"));
            services.AddScoped<IMongoRepository, MongoRepository>();
        }
    }
}

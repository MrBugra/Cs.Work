using Cs.Basket.Core;
using Cs.Basket.Service.Application.CommandHandlers;
using Cs.Basket.Service.Application.QueryHandlers;
using Cs.Basket.Service.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Cs.Basket.Service
{
    public static class StartupExtension
    {
        public static void AddBasketServiceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBasketTransactionService, BasketTransactionService>();              
        }
        public static void AddMediatr(this IServiceCollection services) 
        { 
            services.AddMediatR(Assembly.GetExecutingAssembly());                        
        }
    }
}

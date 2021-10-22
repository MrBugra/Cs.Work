
using AutoMapper;
using Cs.Basket.Api.Model.RequestModels;
using Cs.Basket.Core.Caching;
using Cs.Basket.Core.Mongo;
using Cs.Basket.Service.Application.CommandHandlers;
using Cs.Basket.Service.Application.Queries;
using Cs.Basket.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cs.Basket.Api.Test
{
    public class BasketConrollerTest
    {
        private Cs.Basket.Api.Controllers.BasketTransactionController _controller;        
        public BasketConrollerTest()
        {
        }
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public async Task AddBasket_SampleProductsToBasket(int actionCount)
        {

            _controller = new Controllers.BasketTransactionController(Test.TestFixture.Instance.GetRequiredService<IBasketTransactionService>(),
            Test.TestFixture.Instance.GetRequiredService<IMapper>());            
            for (int i = 0; i < actionCount; i++)
            {
                Assert.IsType<OkObjectResult>(await _controller.AddBasket(new Model.RequestModels.AddBasketRequestModel
                {
                    CustomerId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    UserName = "CicekSever",
                    Products = new List<Guid> {
                Guid.Parse("9029dcf4-18e5-4976-990d-b03ae729cf8c"),
                Guid.Parse("937360b7-35f7-4f1d-8dc4-ce352f14b883")
                }
                }));
            }
        }
        [Fact]
        public async Task AddBasket_OutOfStockException()
        {
            _controller = new Controllers.BasketTransactionController(Test.TestFixture.Instance.GetRequiredService<IBasketTransactionService>(),
            Test.TestFixture.Instance.GetRequiredService<IMapper>());
            Assert.IsType<BadRequestObjectResult>(await _controller.AddBasket(new Model.RequestModels.AddBasketRequestModel
            {
                CustomerId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                UserName = "CicekSever",
                Products = new List<Guid> {
                Guid.Parse("937360b7-35f7-4f1d-8dc4-ce352f14b884")
                }
            }));
        }
        [Fact]
        public async Task AddBasket_InvalidModelState()
        {

            _controller = new Controllers.BasketTransactionController(Test.TestFixture.Instance.GetRequiredService<IBasketTransactionService>(),
            Test.TestFixture.Instance.GetRequiredService<IMapper>());            
            Assert.IsType<BadRequestObjectResult>(await _controller.AddBasket(new AddBasketRequestModel
            {
                CustomerId = Guid.Empty,
                Products = new List<Guid>(),
                UserName = string.Empty
            }));
        }
        [Fact]
        public async Task AddBasdasket_InvalidModelState()
        {
            var aaa = MoqDocuments.Stocks;
            var ssss = MoqDocuments.ProductComposites;
            _controller = new Controllers.BasketTransactionController(Test.TestFixture.Instance.GetRequiredService<IBasketTransactionService>(),
                Test.TestFixture.Instance.GetRequiredService<IMapper>());            
            Assert.IsType<BadRequestObjectResult>(await _controller.AddBasket(new AddBasketRequestModel
            {
                CustomerId = Guid.Empty,
                Products = new List<Guid>(),
                UserName = string.Empty
            }));
        }
    }
}

using Cs.Basket.Core.Caching;
using Cs.Basket.Core.Enums;
using Cs.Basket.Core.Exceptions;
using Cs.Basket.Core.Models;
using Cs.Basket.Core.Mongo;
using Cs.Basket.Model;
using Cs.Basket.MongoRepository.Models;
using Cs.Basket.Service.Application.AttemptCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cs.Basket.Service.Application.CommandHandlers
{
    public class BasketTransactionCommandHandler : IRequestHandler<BasketTransactionAddCommand>
    {
        IMongoRepository _mongoRepository;
        ICacheManager _cacheManager;
        private const int DefaultRedisExpirationTime = 24;
        public BasketTransactionCommandHandler(IMongoRepository mongoRepository, ICacheManager cacheManager)
        {
            _mongoRepository = mongoRepository;
            _cacheManager = cacheManager;
        }
        public async Task<Unit> Handle(BasketTransactionAddCommand request, CancellationToken cancellationToken)
        {
            if (request == default(BasketTransactionAddCommand) || request.CustomerId == Guid.Empty || request.Products == default(List<Model.ProductComposite>))
            {
                throw new CsBusinessException("request parameters incorrect!");
            }

            if (request.Products.Count == default(int))
            {
                throw new CsBusinessException("product list is empty!");
            }

            if (!(await _cacheManager.IsExistsAsync(request.CustomerId.ToString())))
            {
                await _cacheManager.SetAsync(request.CustomerId.ToString(), new BasketModel
                {
                    CustomerId = request.CustomerId,
                    Products = request.Products.Select(x => new ProductBasketModel
                    {
                        Product = x,
                        Quantity = 1
                    }).ToList()
                }, DefaultRedisExpirationTime);

                return Unit.Value;
            }

            var basket = await _cacheManager.GetAsync<BasketModel>(request.CustomerId.ToString());
            request.Products.ForEach(x =>
            {
                if (basket.Products.Any(pr => pr.Product.ProductCompositeId == x.ProductCompositeId))
                {
                    basket.Products.Single(pr => pr.Product.ProductCompositeId == x.ProductCompositeId).Quantity += 1;
                }
                else
                {
                    basket.Products.Add(new ProductBasketModel { Product = x, Quantity = 1 });
                }
            });
            await _cacheManager.SetAsync(request.CustomerId.ToString(), basket, DefaultRedisExpirationTime);

            return Unit.Value;
        }
    }
}

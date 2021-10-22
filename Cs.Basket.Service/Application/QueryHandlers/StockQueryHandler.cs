using Cs.Basket.Core.Exceptions;
using Cs.Basket.Core.Models;
using Cs.Basket.Core.Mongo;
using Cs.Basket.MongoRepository.Models;
using Cs.Basket.Service.Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cs.Basket.Service.Application.QueryHandlers
{
    public class StockQueryHandler : IRequestHandler<CheckStockQuery, CheckStockQueryResult>
    {
        private readonly IMongoRepository _mongoRepository;
        public StockQueryHandler(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository ?? throw new ArgumentNullException(nameof(mongoRepository));
        }
        public async Task<CheckStockQueryResult> Handle(CheckStockQuery request, CancellationToken cancellationToken)
        {
            if (request == default(CheckStockQuery) || request.ProductComponentQuantityModels == default(List<KeyValueModel<int>>))
            {
                throw new CsBusinessException("input parameters incorrect!");
            }

            if (request.ProductComponentQuantityModels.Count == default(int))
            {
                throw new CsBusinessException("input parameters incorrect!");
            }
            var componentQuery = (request.ProductComponentQuantityModels.Select(async (x) =>
            {
                var component = await _mongoRepository.GetAsync<Stock>(comp => comp.ProductComponentId == x.Key && comp.Quantity > x.Value);
                if (component == default(MongoRepository.Models.Stock))
                {
                    throw new CsBusinessException("Product out of stock!");
                }

                return component;
            }));

            return new CheckStockQueryResult
            {
                IsProductComponentsInStock = (await Task.WhenAll(componentQuery)).Select(x => new KeyValueModel<bool> {
                    Key = x.ProductComponentId,
                    Value = true
                }).ToList()
            };
        }
    }
}

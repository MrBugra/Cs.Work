using Cs.Basket.Core.Exceptions;
using Cs.Basket.Core.Mongo;
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
    public class CatalogQueryHandler : IRequestHandler<GetCatalogModelQuery, GetCatalogModelQueryResult>
    {
        private const string CatalogDocument = "Catalog";
        private readonly IMongoRepository _mongoRepository;

        public CatalogQueryHandler(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository ?? throw new ArgumentNullException(nameof(mongoRepository));
        }
        public async Task<GetCatalogModelQueryResult> Handle(GetCatalogModelQuery request, CancellationToken cancellationToken)
        {
            if (request == default(GetCatalogModelQuery) || request.ProductCompositeIds == default(List<Guid>) ||request.ProductCompositeIds.Count == default(int))
            {
                throw new CsBusinessException("Composite ids null!");
            }

            var compositeQueryTasks =  (request.ProductCompositeIds.Select(async (x) =>            
            {
                var composite = await _mongoRepository.GetAsync<MongoRepository.Models.ProductComposite>(comp => comp.ProductCompositeId == x, CatalogDocument);
                if (composite == default(MongoRepository.Models.ProductComposite))
                {
                    throw new CsBusinessException("Product not found!");
                }
                return composite;
            }));

            return new GetCatalogModelQueryResult {
                ProductComposites = (await Task.WhenAll(compositeQueryTasks)).Select(x => new Model.ProductComposite { 
                Name = x.Name,
                Price = x.Price,
                ProductComponents = x.ProductComponents.ToList(),
                ProductCompositeId = x.ProductCompositeId
                }).ToList()
            };
        }
    }
}

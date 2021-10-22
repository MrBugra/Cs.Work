using Cs.Basket.Core.Mongo;
using Cs.Basket.MongoRepository.Models;
using Cs.Basket.Service.Application.AttemptCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cs.Basket.Service.Application.CommandHandlers
{
    public class StockCommandHandler : IRequestHandler<DecreaseStockCommand>
        , IRequestHandler<IncreaseStockCommand>
    {

        private readonly IMongoRepository _mongoRepository;
        public StockCommandHandler(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository ?? throw new ArgumentNullException(nameof(mongoRepository));
        }
        public async Task<Unit> Handle(DecreaseStockCommand request, CancellationToken cancellationToken)
        {
            var stockItem = await _mongoRepository.GetAsync<Stock>(x => x.ProductComponentId == request.ProductComponentId);
            stockItem.Quantity -= request.Quantity;
            await _mongoRepository.UpdateOneAsync<Stock>(x => x.ProductComponentId == request.ProductComponentId, stockItem);

            return Unit.Value;
        }
        public async Task<Unit> Handle(IncreaseStockCommand request, CancellationToken cancellationToken)
        {
            var stockItem = await _mongoRepository.GetAsync<Stock>(x => x.ProductComponentId == request.ProductComponentId);
            stockItem.Quantity += request.Quantity;
            await _mongoRepository.UpdateOneAsync<Stock>(x => x.ProductComponentId == request.ProductComponentId, stockItem);

            return Unit.Value;
        }
    }
}

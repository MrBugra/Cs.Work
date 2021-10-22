using Cs.Basket.Model;
using Cs.Basket.Service.Application.AttemptCommands;
using Cs.Basket.Service.Application.Queries;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cs.Basket.Service.Services
{
    public class BasketTransactionService : IBasketTransactionService
    {
        private readonly IMediator _mediator;
        public BasketTransactionService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task AddBasket(BasketTransactionAddBasketInputModel input)
        {            

            var catalogItems = await _mediator.Send(new GetCatalogModelQuery
            {
                ProductCompositeIds= input.ProductComposites
            });
            await _mediator.Send(new CheckStockQuery {
                ProductComponentQuantityModels = catalogItems.ProductComposites.SelectMany(cmp=>cmp.ProductComponents).Select(stock=> new Core.Models.KeyValueModel<int> { 
                Key = stock.Component.ProductComponentId,
                Value = stock.Quantity
                }).ToList()
            });
            foreach (var item in catalogItems.ProductComposites.SelectMany(cmp => cmp.ProductComponents).Select(x => new DecreaseStockCommand
            {
                ProductComponentId = x.Component.ProductComponentId,
                Quantity = x.Quantity
            }).ToList())
            {
                await _mediator.Send(item);
            };
            await _mediator.Send(new BasketTransactionAddCommand {
            CustomerId = input.CustomerId,
            Products = catalogItems.ProductComposites
            });
        }
    }
}

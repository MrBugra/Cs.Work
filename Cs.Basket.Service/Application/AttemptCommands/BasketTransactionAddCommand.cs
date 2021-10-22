using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Service.Application.AttemptCommands
{
    public class BasketTransactionAddCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public List<Model.ProductComposite> Products { get; set; }
    }  
}

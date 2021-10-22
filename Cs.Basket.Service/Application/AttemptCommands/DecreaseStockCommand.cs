using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Service.Application.AttemptCommands
{
    public class DecreaseStockCommand : IRequest
    {
        public Guid ProductComponentId { get; set; }
        public int Quantity { get; set; }
    }
}

using Cs.Basket.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Service.Application.Queries
{
    public class CheckStockQuery : IRequest<CheckStockQueryResult>
    {
        public List<KeyValueModel<int>> ProductComponentQuantityModels { get; set; }
    }
    public class CheckStockQueryResult
    {
        public List<KeyValueModel<bool>> IsProductComponentsInStock { get; set; }
    }
}

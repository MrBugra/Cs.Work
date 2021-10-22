using Cs.Basket.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Service.Application.Queries
{
    public class GetCatalogModelQuery : IRequest<GetCatalogModelQueryResult>
    {
        public List<Guid> ProductCompositeIds { get; set; }
    }
    public class GetCatalogModelQueryResult
    {
        public List<ProductComposite> ProductComposites { get; set; }
    }
}

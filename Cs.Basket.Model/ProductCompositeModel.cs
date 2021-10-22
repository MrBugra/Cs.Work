using Cs.Basket.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Model
{
    public class ProductComposite
    {       
        public Guid ProductCompositeId { get; set; }
        public IList<ProductComponentQuantityModel> ProductComponents;
        public string Name { get; set; }
        public double Price { get; set; }

    }
    public class ProductComponentQuantityModel
    {
        public ProductComponent Component { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductComponent
    {
        public Guid ProductComponentId { get; set; }
        public string Name { get; set; }
        public ProductComponentSpecificationEnum ProductComponentSpecification { get; set; }
    }
}

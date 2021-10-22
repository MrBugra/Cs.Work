using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Core.Enums
{
    public class ProductComponentSpecificationEnum : Enumeration
    {
        
        public static ProductComponentSpecificationEnum Flower = new ProductComponentSpecificationEnum(1, "Flower");
        public static ProductComponentSpecificationEnum BonnyFood = new ProductComponentSpecificationEnum(2, "BonnyFood");
        public static ProductComponentSpecificationEnum Toy = new ProductComponentSpecificationEnum(3, "Toy");
        public static ProductComponentSpecificationEnum GiftCart = new ProductComponentSpecificationEnum(4, "GiftCart");

        public ProductComponentSpecificationEnum(int id, string name) : base(id, name)
        {
            
        }
    }
}

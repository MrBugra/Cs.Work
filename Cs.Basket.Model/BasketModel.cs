using Cs.Basket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Model
{
    public class BasketModel
    {
        public Guid CustomerId { get; set; }
        public List<Model.ProductBasketModel> Products { get; set; }
    }
    public class ProductBasketModel
    {
        public Model.ProductComposite Product { get; set; }
        public int Quantity { get; set; }
    }
}

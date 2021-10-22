using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Model
{
    public class BasketTransactionAddBasketInputModel
    {
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
        public List<Guid> ProductComposites { get; set; }
    }
}

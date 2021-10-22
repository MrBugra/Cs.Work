using Cs.Basket.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cs.Basket.Service.Services
{
    public interface IBasketTransactionService
    {
        Task AddBasket(BasketTransactionAddBasketInputModel input);
    }
}

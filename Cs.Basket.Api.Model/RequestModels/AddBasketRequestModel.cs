using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Api.Model.RequestModels
{
    public class AddBasketRequestModel
    {
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
        public List<Guid> Products { get; set; }
    }
    public class AddBasketRequestModelValidator : AbstractValidator<AddBasketRequestModel>
    {
        public AddBasketRequestModelValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is empty!");
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("UserName is empty!");
            RuleFor(x => x.Products).NotNull().WithMessage("ProductList is null");
            RuleFor(x => x.Products.Count).GreaterThan(default(int)).WithMessage("ProductList is empty!");
        }
    }
}

using AutoMapper;
using Cs.Basket.Api.Model.RequestModels;
using Cs.Basket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cs.Basket.Api.Mapper
{
    public class RequestMapperProfile : Profile
    {
        public RequestMapperProfile()
        {
            CreateMap<AddBasketRequestModel, BasketTransactionAddBasketInputModel>()
                .ForMember(x=>x.ProductComposites,y=>y.MapFrom(map=>map.Products));
        }
    }
}

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Cs.Basket.Api.Model;
using Cs.Basket.Api.Model.RequestModels;
using Cs.Basket.Core.Exceptions;
using Cs.Basket.Core.Models;
using Cs.Basket.Model;
using Cs.Basket.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cs.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketTransactionController : ControllerBase
    {
        private readonly IBasketTransactionService _basketTransactionService;
        private readonly IMapper _mapper;

        public BasketTransactionController(
            IBasketTransactionService basketTransactionService, IMapper mapper
        )
        {
            _basketTransactionService = basketTransactionService ?? throw new ArgumentNullException(nameof(basketTransactionService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost(BasketApiMethodConsts.AddBasket)]
        public async Task<IActionResult> AddBasket([FromBody] AddBasketRequestModel request)
        {
            try
            {
                await _basketTransactionService.AddBasket(_mapper.Map<BasketTransactionAddBasketInputModel>(request));

                return Ok(new ApiResponse
                {
                    Code = (int)HttpStatusCode.OK,
                    Message = string.Empty
                });
            }
            catch (CsBusinessException ex)
            {
                return BadRequest(new ApiResponse
                {
                    Code = (int)HttpStatusCode.ServiceUnavailable,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

                return BadRequest(new ApiResponse
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = ex.Message.ToString()
                });
            }
        }
    }
}
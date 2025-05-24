using E_Commerce.Api.Errors;
using E_Commerce.Core.DataTransferObjects;
using E_Commerce.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<ActionResult<BasketDto>> Get(string id)
        {
            var basket = await _basketService.GetBasketAsync(id);
            return basket is null ? NotFound(new ApiResponse(404 , $"Basket With Id {id} Not Found")): Ok(basket);
        }


        [HttpPost]
        public async Task<ActionResult<BasketDto>> update(BasketDto basketDto)
        {
            var basket = await _basketService.UpdateBasketAsync(basketDto);
            return basket is null ? NotFound(new ApiResponse(404, $"Basket With Id {basketDto.Id} Not Found")) : Ok(basket);
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
            =>  Ok( await _basketService.DeleteBasketAsync(id));


    }
}

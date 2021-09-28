using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddtoBasketAPI.Service;
using System.ComponentModel.DataAnnotations;

namespace AddtoBasketAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly Service.BasketService basketService;
        private readonly ProductService productService;

        public BasketController(Service.BasketService basketService, ProductService productService)
        {
            this.basketService = basketService;
            this.productService = productService;
        }

        [HttpGet("Get")]

        public async Task<IActionResult> Get([Required] int id)
        {
            var result = await basketService.Get(id);

            if (result == null)
                return NotFound("Sepet bulunamadı!");

            return Ok(result);
        }


        [HttpPost("AddBasket")]
        public async Task<IActionResult> AddBasket([Required] int productId, [Required] int total, int basketId)
        {
            var product = await productService.Get(productId);

            if (product == null)
                return NotFound("Ürün bulunamadı!");

            var addBasket = await basketService.AddBasket(productId, total, basketId);

            if (addBasket == null)
                return NotFound("Ürün sepete eklenemedi!");

            return Ok(addBasket);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddtoBasketAPI.Model;
using AddtoBasketAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddtoBasketAPI.Controllers;
using AddtoBasketAPI.Service;
using System.ComponentModel.DataAnnotations;

namespace AddtoBasketAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService stockService;
        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await stockService.GetAll();
            return Ok(result);
        }

        [HttpPut("ChangeAmount")]
        public async Task<IActionResult> ChangeAmount([Required] int productId, [Required] int productTotal)
        {
            var changeAmountResponse = await stockService.ChangeAmount(productId, productTotal);
            if (changeAmountResponse != null)
                return Ok(new ApiResults<Stock>(changeAmountResponse, true, "Stok azaltıldı."));

            return NotFound(new ApiResults<Stock>(null, false, "Stokta ürün bulunamadı!"));
        }
    }
}

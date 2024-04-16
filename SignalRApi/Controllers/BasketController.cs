using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BL.Abstract;
using SignalR.DAL.Concrete;
using SignalRApi.Models;

namespace SignalRApi.Controllers
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
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values=_basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context=new SignalRContext();//solid biraz ezilmek zorunda kaldı
            var values= context.Baskets.Include(x => x.Product).Where(y => y.MenuTableId == id)
                .Select(z => new ResultBasketListWithProducts
            {
                    BasketId=z.BasketId,
                    Count=z.Count,
                    MenuTableId=z.MenuTableId,
                    Price=z.Price,
                    ProductId=z.ProductId,
                    TotalPrice = z.TotalPrice,
                    ProductName = z.Product.ProductName,

                }).ToList();
            return Ok(values);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BL.Abstract;
using SignalR.Dto.ContantDto;
using SignalR.Dto.DiscountDto;
using SignalR.Entity.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
                DiscountAmount=createDiscountDto.DiscountAmount,
                DiscountDescription=createDiscountDto.DiscountDescription,
                DiscountImageUrl=createDiscountDto.DiscountImageUrl,
               DiscountTitle = createDiscountDto.DiscountTitle 
            });
            return Ok("indirim bilgisi eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("iletişim bilgisi silindi");
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
               DiscountTitle=updateDiscountDto.DiscountTitle,
               DiscountDescription=updateDiscountDto.DiscountDescription,
               DiscountImageUrl=updateDiscountDto.DiscountImageUrl,
               DiscountAmount = updateDiscountDto.DiscountAmount,
               DiscountId = updateDiscountDto.DiscountId
            });
            return Ok("indirim  güncellendi");
        }
    }
}

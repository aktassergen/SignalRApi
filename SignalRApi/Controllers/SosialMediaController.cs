using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BL.Abstract;
using SignalR.Dto.ContantDto;
using SignalR.Dto.ProductDto;
using SignalR.Dto.SosialMediaDto;
using SignalR.Entity.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SosialMediaController : ControllerBase
    {
        private readonly ISosialMediaService _sosialMediaService;
        private readonly IMapper _mapper;

        public SosialMediaController(ISosialMediaService sosialMediaService, IMapper mapper)
        {
            _sosialMediaService = sosialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SosialMediaList()
        {
            var value = _mapper.Map<List<ResultSosialMediaDto>>(_sosialMediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult SosialMediaFeature(CreateSosialMediaDto createSosialMediaDto)
        {
            _sosialMediaService.TAdd(new SosialMedia()
            {
                SocialIcon = createSosialMediaDto.SocialIcon,
                SocialTitle = createSosialMediaDto.SocialTitle,
                SocialUrl = createSosialMediaDto.SocialUrl,
            });
            return Ok("Sosya Medya bilgisi eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSosialMedia(int id)
        {
            var value = _sosialMediaService.TGetById(id);
            _sosialMediaService.TDelete(value);
            return Ok("ürün bilgisi silindi");
        }
        [HttpGet(("{id}"))]
        public IActionResult GetSosialMedia(int id)
        {
            var value = _sosialMediaService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSosialMedia(UpdateSosialMediaDto updateSosialMediaDto)
        {
            _sosialMediaService.TUpdate(new SosialMedia()
            {
               SocialUrl=updateSosialMediaDto.SocialUrl,
               SocialTitle=updateSosialMediaDto.SocialTitle,
               SocialIcon=updateSosialMediaDto.SocialIcon,
               SocialMediaId = updateSosialMediaDto.SocialMediaId
            });
            return Ok("sosyal medya  güncellendi");
        }
    }
}

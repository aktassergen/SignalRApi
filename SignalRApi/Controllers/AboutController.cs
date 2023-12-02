using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using SignalR.BL.Abstract;
using SignalR.Dto.AboutDto;
using SignalR.Entity.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values=_aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                AboutDescription = createAboutDto.AboutDescription,
                AboutImageUrl = createAboutDto.AboutImageUrl,
                AboutTitle = createAboutDto.AboutTitle,
            };
            _aboutService.TAdd(about);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value=_aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkında Alanı Silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutDescription = updateAboutDto.AboutDescription,
                AboutImageUrl = updateAboutDto.AboutImageUrl,
                AboutTitle = updateAboutDto.AboutTitle,
                AboutId = updateAboutDto.AboutId,
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımızda alanı güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value=_aboutService.TGetById(id);
            return Ok(value);
        }
    }
}

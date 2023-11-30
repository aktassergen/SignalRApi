using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BL.Abstract;
using SignalR.Dto.ContantDto;
using SignalR.Entity.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContantService _contantService;
        private readonly IMapper _mapper;

        public ContactController(IContantService contantService, IMapper mapper)
        {
            _contantService = contantService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContantDto>>(_contantService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContantDto createContactDto)
        {
            _contantService.TAdd(new Contant()
            {
                ContantLocation=createContactDto.ContantLocation,
                ContantMail=createContactDto.ContantMail,
                ContantPhone=createContactDto.ContantPhone,
                FooterDerscription=createContactDto.FooterDerscription,
            });
            return Ok("iletişim bilgisi eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contantService.TGetById(id);
            _contantService.TDelete(value);
            return Ok("iletişim bilgisi silindi");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contantService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContantDto updateContactDto)
        {
            _contantService.TUpdate(new Contant()
            {
                ContantLocation=updateContactDto.ContantLocation,
                ContantMail=updateContactDto.ContantMail,
                ContantPhone=updateContactDto.ContantPhone,
                FooterDerscription=updateContactDto.FooterDerscription,
                ContantId=updateContactDto.ContantId,
            });
            return Ok("kategori eklendi");
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BL.Abstract;
using SignalR.Dto.TestimonialDto;
using SignalR.Entity.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService TestimonialService, IMapper mapper)
        {
            _testimonialService = TestimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult TestimonialFeature(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                TestimonialComment=createTestimonialDto.TestimonialComment,
                TestimonialImageUrl=createTestimonialDto.TestimonialImageUrl,
                TestimonialName=createTestimonialDto.TestimonialName,
                TestimonialStatus = createTestimonialDto.TestimonialStatus,
                TestimonialTitle = createTestimonialDto.TestimonialTitle
            });
            return Ok("müşteri yorum bilgisi eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("müşteri yorum silindi");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialImageUrl=updateTestimonialDto.TestimonialImageUrl,
              TestimonialId=updateTestimonialDto.TestimonialId,
              TestimonialTitle=updateTestimonialDto.TestimonialTitle,
              TestimonialStatus = updateTestimonialDto.TestimonialStatus,
              TestimonialName=updateTestimonialDto.TestimonialName,
              TestimonialComment = updateTestimonialDto.TestimonialComment
              

            });
            return Ok("müşteri yorum  güncellendi");
        }
    }
}

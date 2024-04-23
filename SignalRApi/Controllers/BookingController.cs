using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BL.Abstract;
using SignalR.Dto.BookingDto;
using SignalR.Entity.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var value = _bookingService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingPhone = createBookingDto.BookingPhone,
                BookingName = createBookingDto.BookingName,
                BookingCount = createBookingDto.BookingCount,
                BookingDate = createBookingDto.BookingDate,
                BookingMail = createBookingDto.BookingMail,
                BookingDescription = createBookingDto.BookingDescription,
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value=_bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("silme işlemi yapıldı");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingCount = updateBookingDto.BookingCount,
                BookingDate = updateBookingDto.BookingDate,
                BookingMail = updateBookingDto.BookingMail,
                BookingId = updateBookingDto.BookingId,
                BookingName = updateBookingDto.BookingName,
                BookingPhone = updateBookingDto.BookingPhone,
                BookingDescription= updateBookingDto.BookingDescription,
            };
            _bookingService.TUpdate(booking);
            return Ok("guncelleme islemi yapildi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value=_bookingService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
		[HttpGet("BookingStatusCancelled/{id}")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingService.TBookingStatusCancelled(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi");
		}
	}
	
}

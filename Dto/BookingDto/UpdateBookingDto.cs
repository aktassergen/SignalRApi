using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Dto.BookingDto
{
    public class UpdateBookingDto
    {
        public int BookingId { get; set; }
        public string BookingName { get; set; }
		public string BookingDescription { get; set; }
		public string BookingPhone { get; set; }
        public string BookingMail { get; set; }
        public int BookingCount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}

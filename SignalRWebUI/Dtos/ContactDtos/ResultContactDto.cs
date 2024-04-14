using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.ContactDtos
{
    public class ResultContactDto
    {
        public int ContantId { get; set; }
        public string ContantLocation { get; set; }
        public string ContantPhone { get; set; }
        public string ContantMail { get; set; }
        public string FooterTitle { get; set; }
        public string FooterDerscription { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHours { get; set; }
    }
}

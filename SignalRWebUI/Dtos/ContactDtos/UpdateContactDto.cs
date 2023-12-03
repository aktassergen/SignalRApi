using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        public int ContantId { get; set; }
        public string ContantLocation { get; set; }
        public string ContantPhone { get; set; }
        public string ContantMail { get; set; }
        public string FooterDerscription { get; set; }
    }
}

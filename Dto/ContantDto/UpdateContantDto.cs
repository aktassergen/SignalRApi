using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Dto.ContantDto
{
    public class UpdateContantDto
    {
        public int ContantId { get; set; }
        public string ContantLocation { get; set; }
        public string ContantPhone { get; set; }
        public string ContantMail { get; set; }
        public string FooterDerscription { get; set; }
    }
}

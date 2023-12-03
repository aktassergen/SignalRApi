using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.SosialMediaDtos
{
	public class UpdateSosialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string SocialTitle { get; set; }
        public string SocialUrl { get; set; }
        public string SocialIcon { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Requests
{
    public class SendMessageRequest
    {
        public string userId { get; set; }
        public int GroupId { get; set; }
        public string msg { get; set; }
    }
}

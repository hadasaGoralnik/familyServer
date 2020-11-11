using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Requests
{
    public class AddChatMessageRequest
    {
        public string Body { get; set; }
        public int UserID { get; set; }
        public int GroupId { get; set; }

    }
}

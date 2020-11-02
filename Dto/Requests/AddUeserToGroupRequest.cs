using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Requests
{
   public class AddUeserToGroupRequest
    {
        public int GroupId { get; set; }
        public string UserSender { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }
        public string Password { get; set; }
    }
}

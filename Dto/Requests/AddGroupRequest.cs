using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Requests
{
    public class AddGroupRequest
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }


    }
}

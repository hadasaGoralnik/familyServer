using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Requests
{
  public  class DeleteUserFromGroupRequest
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}

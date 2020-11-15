using Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class UserDto
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<System.DateTime> MarryDate { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsMale { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public virtual List<ChatMessagesDto> ChatMessages { get; set; }
        public virtual List<EventsDto> Events { get; set; }
        public virtual List<MenuDto> Menu { get; set; }
        public virtual List<MessageDto> Message { get; set; }
        public virtual List<GroupsDto> Groups { get; set; }

    }
}

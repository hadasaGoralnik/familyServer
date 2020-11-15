using Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class GroupsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual List<ChatMessagesDto> ChatMessages { get; set; }
        public virtual List<EventsDto> Events { get; set; }
        public virtual List<UserDto> User { get; set; }

    }
}

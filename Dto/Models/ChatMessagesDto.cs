using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Models
{
    public class ChatMessagesDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
    }
}

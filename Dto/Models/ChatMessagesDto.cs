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
        public string Title { get; set; }
        public int UserID { get; set; }
        public System.DateTime Date { get; set; }
        public int EventsId { get; set; }
    }
}

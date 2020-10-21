using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public System.DateTime Dest_Date { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int EventId { get; set; }
    }
}

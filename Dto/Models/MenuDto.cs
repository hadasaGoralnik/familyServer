using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class MenuDto
    {
        public int Id { get; set; }
        public int MenuOrderNumber { get; set; }
        public int VolunteerId { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Cost { get; set; }
    }
}

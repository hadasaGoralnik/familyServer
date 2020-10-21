using Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dto
{
    public class EventsDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public int Promoter { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> IsDairy { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<int> Repeat { get; set; }
        public int EventKindId { get; set; }
        public List<ChatMessagesDto> ChatMessages { get; set; }
        public List<MenuDto> Menu { get; set; }
        public List<MessageDto> Message { get; set; }
        public List<PictureDto> Picture { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bl
{
    public class EventService
    {
        public static EventsDto PostEvent(EventsDto events)
        {
            using (familydbEntities3 db = new familydbEntities3())
            {
                //db.Groups.ToList().ForEach(x =>
                //{
                //    x.Users.ToList().ForEach(y => {y.Id == "342");
                //});
                db.Events.Add(Convertion.EventsConvertion.ConvertToEvent(events));
                db.SaveChanges();
                return events;
            }
        }
        public static List<EventsDto> Get(int group)
        {
            using (familydbEntities3 db = new familydbEntities3())
            {
                List<Events> find = new List<Events>();
                find = db.Events.Where(x => x.GroupId == group).ToList();
                if (find == null)
                    return null;
                return Convertion.EventsConvertion.ConvertToDtoList(find).ToList();
            }
        }
    }
}

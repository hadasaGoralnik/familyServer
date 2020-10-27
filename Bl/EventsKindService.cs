using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bl
{
    public class EventsKindService
    {
        public static List<EventsKindDto> GetEventsKinds()
        {
            using (familydbEntities2 db = new familydbEntities2())
            {

               List<EventsKindDto>  eventsKinds = new List<EventsKindDto>();
                db.EventsKinds.ToList().ForEach(x =>
                {
                    eventsKinds.Add(Convertion.EventsKindConvertion.ConvertToDto(x));
                });
                return eventsKinds;
            }
        }
    }
}

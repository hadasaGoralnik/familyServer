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
            using (familydbEntities5 db = new familydbEntities5())
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

        public static EventsDto GetEventById(int eventId)
        {
            using (familydbEntities5 db = new familydbEntities5())
            {
                Events find = new Events();
                find = db.Events.Include("User").Include("EventsKind").Include("Groups").FirstOrDefault(x => x.Id == eventId);
                if (find == null)
                return null;
                return Convertion.EventsConvertion.ConvertToDto(find);
            }
        }
        public static EventsDto CreateEvents(EventsDto events)
        {

            using (familydbEntities8 db = new familydbEntities8())
            {
                Events events1 = new Events();
                events1 = db.Events.Add(Convertion.EventsConvertion.ConvertToEvent(events));
                db.SaveChanges();
                if (events1 == null)
                    return null;
                return Convertion.EventsConvertion.ConvertToDto(events1);
            }
        }

        public static void SaveImage(int id, string fileName, string name)
        {
            using (familydbEntities8 db = new familydbEntities8())
            {
                Events find = new Events();
                var pic = new Picture() {EventId=id,Image= fileName, Name=name };
                db.Picture.Add(pic);
                db.SaveChanges();
            }
        }

        public static List<EventsKindDto> GetAllEventsKind()
        {
            using (familydbEntities5 db = new familydbEntities5())
            {
                List<EventsKindDto> find = new List<EventsKindDto>();
                var events= db.EventsKind.ToList();
                foreach (var item in events)
                {
                    find.Add(Convertion.EventsKindConvertion.ConvertToDto(item))  ;
                }  
                if (find == null)
                    return null;
                return find;
            }
        }

        public static List<PictureDto>  GetPicturesByEventId(int eventId)
        {
            using (familydbEntities5 db = new familydbEntities5())
            {
                List<Picture> find = new List<Picture>();
                find = db.Picture.Where(x => x.EventId == eventId).ToList();
                if (find == null)
                    return null;
                return Convertion.PictureConvertion.ConvertToDtoList(find).ToList();
            }
        }

        public static List<EventsDto> Get(int group)
        {
            using (familydbEntities5 db = new familydbEntities5())
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

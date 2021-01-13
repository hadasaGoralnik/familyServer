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
            using (familydbEntities9 db = new familydbEntities9())
            {
                db.Events.Add(Convertion.EventsConvertion.ConvertToEventNoChildren(events));
                db.SaveChanges();
                return events;
            }
        }

        public static EventsDto GetEventById(int eventId)
        {
            using (familydbEntities9 db = new familydbEntities9())
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

            using (familydbEntities9 db = new familydbEntities9())
            {
                Events events1 = Convertion.EventsConvertion.ConvertToEventNoChildren(events);
                db.Events.Add(events1);
                db.SaveChanges();
                return Convertion.EventsConvertion.ConvertToDto(events1);
            }
        }


        public static void SaveImage(int id, string fileName, string name)
        {
            using (familydbEntities9 db = new familydbEntities9())
            {
                Events find = new Events();
                var pic = new Picture() {EventId=id,Image= fileName, Name=name };
                db.Picture.Add(pic);
                db.SaveChanges();
            }
        }

        public static List<EventsKindDto> GetAllEventsKind()
        {
            using (familydbEntities9 db = new familydbEntities9())
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

        public static EventsDto DeleteEvent(int events)
        {
            using (familydbEntities9 db = new familydbEntities9())
            {
                List<Menu> find = new List<Menu>();
                find = db.Menu.Where(x => x.EventId == events).ToList();
                foreach (var item in find)
                {
                    db.Menu.Remove(item);
                }
                List<Picture> find1 = new List<Picture>();
                find1 = db.Picture.Where(x => x.EventId == events).ToList();
                foreach (var item in find1)
                {
                    db.Picture.Remove(item);
                }
                Events e = db.Events.Where(x => x.Id == events).FirstOrDefault();
                EventsDto e1= Convertion.EventsConvertion.ConvertToDto(e);
                db.Events.Remove(e);
                db.SaveChanges();
                return e1;
            }
        }

        public static EventsDto UpdateEvents(EventsDto events)
        {
            using (familydbEntities9 db = new familydbEntities9())
            {
                var events1=db.Events.FirstOrDefault(e => e.Id == events.Id);
                if(events1!=null)
                {
                    Events e = Convertion.EventsConvertion.ConvertToEventNoChildren(events);
                    events1.Address = e.Address;
                    events1.City = e.City;
                    events1.Comment = e.Comment;
                    events1.Date = e.Date;
                    events1.Description = e.Description;
                    events1.EventKindId = e.EventKindId;
                    events1.EventsKind = e.EventsKind;
                    events1.GroupId = e.GroupId;
                    events1.Id = e.Id;
                    events1.IsDairy = e.IsDairy;
                    events1.Promoter = e.Promoter;
                    events1.Repeat = e.Repeat;
                    events1.Title = e.Title;
                }
                db.SaveChanges();

                return Convertion.EventsConvertion.ConvertToDto(events1);
            }
        }

        public static List<PictureDto>  GetPicturesByEventId(int eventId)
        {
            using (familydbEntities9 db = new familydbEntities9())
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
            using (familydbEntities9 db = new familydbEntities9())
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

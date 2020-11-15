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
            using (familydbEntities4 db = new familydbEntities4())
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
            using (familydbEntities4 db = new familydbEntities4())
            {
                Events find = new Events();
                find = db.Events.Include("User").Include("EventsKind").Include("Groups").FirstOrDefault(x => x.Id == eventId);
                if (find == null)
                return null;
                return Convertion.EventsConvertion.ConvertToDto(find);
            }
        }

        public static List<MenuDto> GetMenusByEventId(int eventId)
        {
            using (familydbEntities4 db = new familydbEntities4())
            {
                List<Menu> find = new List<Menu>();
                find = db.Menu.Where(x => x.EventId == eventId).ToList();
                if (find == null)
                    return null;
                return Convertion.MenuConvertion.ConvertToDtoList(find).ToList();
            }
        }

        public static List<PictureDto>  GetPicturesByEventId(int eventId)
        {
            using (familydbEntities4 db = new familydbEntities4())
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
            using (familydbEntities4 db = new familydbEntities4())
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

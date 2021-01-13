using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Dal;
using Dto;
namespace Bl.Convertion
{
   public class EventsConvertion
    {
        public static EventsDto ConvertToDto(Events events)
        {
            EventsDto newEvent = new EventsDto();
            newEvent.Comment = events.Comment;
            newEvent.Date = events.Date;
            newEvent.Description = events.Description;
            newEvent.Id = events.Id;
            newEvent.Promoter = events.Promoter;
            newEvent.City = events.City;
            newEvent.Description = events.Description;
            newEvent.GroupId = events.GroupId;
            newEvent.Address = events.Address;
            newEvent.EventKindId = events.EventKindId;
            newEvent.IsDairy = events.IsDairy;
            newEvent.Repeat = events.Repeat;
            newEvent.Title = events.Title;
            newEvent.User = events.User == null? new UserDto(): UserConvertion.ConvertToDto(events.User);
            newEvent.EventsKind = events.EventsKind == null ? new EventsKindDto() : EventsKindConvertion.ConvertToDto(events.EventsKind);
            newEvent.Groups = events.Groups == null ? new GroupsDto() : GroupsConvertion.ConvertToSingleDto(events.Groups);
            return newEvent;
        }
      
        public static Events ConvertToEvent(EventsDto events)
        {
            Events newEvent = new Events();
            newEvent.Comment = events.Comment;
            newEvent.Date = events.Date;
            newEvent.Description = events.Description;
            newEvent.Id = events.Id;
            newEvent.Promoter = events.Promoter;
            newEvent.City = events.City;
            newEvent.Description = events.Description;
            newEvent.GroupId = events.GroupId;
            newEvent.Address = events.Address;
            newEvent.EventKindId = events.EventKindId;
            newEvent.IsDairy = events.IsDairy;
            newEvent.Repeat = events.Repeat;
            newEvent.Title = events.Title;
            newEvent.User = newEvent.User == null ? new User() : UserConvertion.ConvertToUser(events.User);
            newEvent.EventsKind = newEvent.EventsKind == null ? new EventsKind() : EventsKindConvertion.ConvertToEventsKind(events.EventsKind);
            newEvent.Groups = newEvent.Groups == null ? new Groups() : GroupsConvertion.ConvertToGroups(events.Groups);
            return newEvent;
        }

        public static Events ConvertToEventNoChildren(EventsDto events)
        {
            Events newEvent = new Events();
            newEvent.Comment = events.Comment;
            newEvent.Date = events.Date;
            newEvent.Description = events.Description;
            newEvent.Id = events.Id;
            newEvent.Promoter = events.Promoter;
            newEvent.City = events.City;
            newEvent.Description = events.Description;
            newEvent.GroupId = events.GroupId;
            newEvent.Address = events.Address;
            newEvent.EventKindId = events.EventKindId;
            newEvent.IsDairy = events.IsDairy;
            newEvent.Repeat = events.Repeat;
            newEvent.Title = events.Title;
            newEvent.User =  null;
            newEvent.EventsKind = null;
            newEvent.Groups = null;
            return newEvent;
        }
        public static List<EventsDto> ConvertToDtoList(List<Events> e)
        {
            List<EventsDto> newEvent = new List<EventsDto>();
            e.ForEach(x =>
            {
                newEvent.Add(ConvertToDto(x));
            });
            return newEvent;
        }

        public static List<Events> convertToListEvent(List<EventsDto> e)
        {
            List<Events> newEvent = new List<Events>();
            e.ForEach(x =>
            {
                newEvent.Add(ConvertToEvent(x));
            });
            return newEvent;
        }
    }
}


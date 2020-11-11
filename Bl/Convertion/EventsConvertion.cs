using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            newEvent.EventKindId = newEvent.EventKindId;
            newEvent.IsDairy = newEvent.IsDairy;
            newEvent.Message = newEvent.Message;
            newEvent.Picture = newEvent.Picture;
            newEvent.Repeat = events.Repeat;
            newEvent.Menu = MenuConvertion.ConvertToDtoList(events.Menu.ToList());
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
            newEvent.Address = events.Address;
            newEvent.EventKindId = newEvent.EventKindId;
            newEvent.IsDairy = newEvent.IsDairy;
            newEvent.Message = newEvent.Message;
            newEvent.Picture = newEvent.Picture;
            newEvent.Repeat = events.Repeat;
            newEvent.Menu = MenuConvertion.convertToListMenu(events.Menu);
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


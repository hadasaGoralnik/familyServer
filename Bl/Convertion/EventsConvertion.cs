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
        public static EventsDto ConvertToDto(Event events)
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
            newEvent.Message =newEvent.Message;
            newEvent.Picture = newEvent.Picture;
            newEvent.Repeat = events.Repeat;
            newEvent.ChatMessages = ChatMessagesConvertor.ConvertToDtoList(events.ChatMessages.ToList());
            newEvent.Menu = MenuConvertion.ConvertToDtoList(events.Menus.ToList());
            return newEvent;
        }
        public static Event ConvertToEvent(EventsDto events)
        {
            Event newEvent = new Event();
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
            newEvent.Messages = newEvent.Messages;
            newEvent.Pictures = newEvent.Pictures;
            newEvent.Repeat = events.Repeat;
            newEvent.ChatMessages = ChatMessagesConvertor.convertToListChatMessages(events.ChatMessages);
            newEvent.Menus = MenuConvertion.convertToListMenu(events.Menu);
            return newEvent;
        }
        public static List<EventsDto> ConvertToDtoList(List<Event> e)
        {
            List<EventsDto> newEvent = new List<EventsDto>();
            e.ForEach(x =>
            {
                newEvent.Add(ConvertToDto(x));
            });
            return newEvent;
        }
        public static List<Event> convertToListEvent(List<EventsDto> e)
        {
            List<Event> newEvent = new List<Event>();
            e.ForEach(x =>
            {
                newEvent.Add(ConvertToEvent(x));
            });
            return newEvent;
        }
    }
}


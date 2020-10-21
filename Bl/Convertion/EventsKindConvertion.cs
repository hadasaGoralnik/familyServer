using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bl.Convertion
{
    public class EventsKindConvertion
    {
        public static EventsKindDto ConvertToDto(EventsKind EventsKind)
        {
            EventsKindDto newEventsKInd = new EventsKindDto();
            newEventsKInd.Id = EventsKind.Id;
            newEventsKInd.Name = EventsKind.Name;
            newEventsKInd.Events= EventsConvertion.ConvertToDtoList(EventsKind.Events.ToList());
            return newEventsKInd;
        }
        public static EventsKind ConvertToEventsKind(EventsKindDto EventsKind)
        {
            EventsKind newEventsKInd = new EventsKind();
            newEventsKInd.Id = EventsKind.Id;
            newEventsKInd.Name = EventsKind.Name;
            newEventsKInd.Events = EventsConvertion.convertToListEvent(EventsKind.Events);
            return newEventsKInd;
        }
    }
}


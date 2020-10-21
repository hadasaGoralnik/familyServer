using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bl.Convertion
{
    public class MessageConvertion
    {
        public static MessageDto ConvertToDto(Message message)
        {
            MessageDto newMessage = new MessageDto();
            newMessage.Dest_Date = message.Dest_Date;
            newMessage.Id= message.Id;
            newMessage.Title = message.Title;
            newMessage.UserID = message.UserID;
            newMessage.Body = message.Body;
            newMessage.EventId = message.EventId;
            return newMessage;
        }
        public static Message ConvertToMessage(MessageDto message)
        {
            Message newMessage = new Message();
            newMessage.Dest_Date = message.Dest_Date;
            newMessage.Id = message.Id;
            newMessage.Title = message.Title;
            newMessage.UserID = message.UserID;
            newMessage.Body = message.Body;
            newMessage.EventId = message.EventId;
            return newMessage;
        }
        public static List<MessageDto> ConvertToDtoList(List<Message> m)
        {
            List<MessageDto> newMessage = new List<MessageDto>();
            m.ForEach(x =>
            {
                newMessage.Add(ConvertToDto(x));
            });
            return newMessage;
        }
        public static List<Message> convertToListMessage(List<MessageDto> m)
        {
            List<Message> newMessage = new List<Message>();
            m.ForEach(x =>
            {
                newMessage.Add(ConvertToMessage(x));
            });
            return newMessage;
        }
    }
}

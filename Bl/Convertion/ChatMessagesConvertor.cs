using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
using Dto.Models;

namespace Bl.Convertion
{
    public class ChatMessagesConvertor
    {
        public static ChatMessagesDto ConvertToDto(ChatMessage chatMessages)
        {
            ChatMessagesDto newChatMessages = new ChatMessagesDto();
            newChatMessages.Date = chatMessages.Date;
            newChatMessages.EventsId = chatMessages.EventId;
            newChatMessages.Id = chatMessages.Id;
            newChatMessages.Title = chatMessages.Title;
            newChatMessages.UserID = chatMessages.UserID;
            return newChatMessages;
        }
        public static ChatMessage ConvertToChatMessages(ChatMessagesDto chatMessages)
        {
            ChatMessage newChatMessages = new ChatMessage();
            newChatMessages.Date = chatMessages.Date;
            newChatMessages.EventId = chatMessages.EventsId;
            newChatMessages.Id = chatMessages.Id;
            newChatMessages.Title = chatMessages.Title;
            newChatMessages.UserID = chatMessages.UserID;
            return newChatMessages;
        }
        public static List<ChatMessagesDto> ConvertToDtoList(List<ChatMessage> c)
        {
            List<ChatMessagesDto> ChatMessages = new List<ChatMessagesDto>();
            c.ForEach(x =>
            {
                ChatMessages.Add(ConvertToDto(x));
            });
            return ChatMessages;
        }
        public static List<ChatMessage> convertToListChatMessages(List<ChatMessagesDto> c)
        {
            List<ChatMessage> ChatMessages = new List<ChatMessage>();
            c.ForEach(x =>
            {
                ChatMessages.Add(ConvertToChatMessages(x));
            });
            return ChatMessages;
        }
    }
}

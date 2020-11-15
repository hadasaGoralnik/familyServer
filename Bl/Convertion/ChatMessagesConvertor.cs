using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
using Dto.Models;
using Dto.Requests;

namespace Bl.Convertion
{
    public class ChatMessagesConvertor
    {
        public static ChatMessagesDto ConvertToDto(ChatMessages chatMessages)
        {
            ChatMessagesDto newChatMessages = new ChatMessagesDto();
            newChatMessages.Date = chatMessages.Date;
            newChatMessages.Id = chatMessages.Id;
            newChatMessages.GroupId = chatMessages.GroupId;
            newChatMessages.Body = chatMessages.Body;
            newChatMessages.UserId = chatMessages.UserId;
            return newChatMessages;
        }
        public static ChatMessages ConvertToChatMessages(ChatMessagesDto chatMessages)
        {
            ChatMessages newChatMessages = new ChatMessages();
            newChatMessages.Date = chatMessages.Date;
            newChatMessages.Id = chatMessages.Id;
            newChatMessages.GroupId = chatMessages.GroupId;
            return newChatMessages;
        }
        public static List<ChatMessagesDto> ConvertToDtoList(List<ChatMessages> c)
        {
            List<ChatMessagesDto> ChatMessages = new List<ChatMessagesDto>();
            c.ForEach(x =>
            {
                ChatMessages.Add(ConvertToDto(x));
            });
            return ChatMessages;
        }
        public static List<ChatMessages> convertToListChatMessages(List<ChatMessagesDto> c)
        {
            List<ChatMessages> ChatMessages = new List<ChatMessages>();
            c.ForEach(x =>
            {
                ChatMessages.Add(ConvertToChatMessages(x));
            });
            return ChatMessages;
        }
        public static ChatMessages ConvertAddChatMessageRequestToChatMessages(AddChatMessageRequest request)
        {
            ChatMessages newChatMessages = new ChatMessages();
            newChatMessages.Date = DateTime.Now;
            newChatMessages.GroupId = request.GroupId;
            newChatMessages.UserId = request.UserID;
            newChatMessages.Body = request.Body;
            return newChatMessages;
        }
        
    }
}

using Dal;
using Dto.Interfaces;
using Dto.Models;
using Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class ChatService:IChatService
    {
        public Dictionary<int, Dictionary<int, WebSocket>> websockets { get; set; }
        public ChatService()
        {
            websockets = new Dictionary<int, Dictionary<int,WebSocket>>();
        }

        public static ChatMessagesDto AddChatMessage(AddChatMessageRequest request)
        {
            using (familydbEntities5 db = new familydbEntities5())
            {

                ChatMessages msg = db.ChatMessages.Add(Convertion.ChatMessagesConvertor.ConvertAddChatMessageRequestToChatMessages(request));
                db.SaveChanges();
                if (msg == null)
                    return null;
                return Convertion.ChatMessagesConvertor.ConvertToDto(msg);
            }
        }
        public static List<ChatMessagesDto> GetMessages(int groupId)
        {
            using (familydbEntities5 db = new familydbEntities5())
            {
                // Groups find = new Groups();
                var msgIds = (from msg in db.ChatMessages
                                where msg.GroupId== groupId
                              select msg.Id).ToList();
                var find = db.ChatMessages
                    .Where(x => msgIds.Contains(x.Id)).ToList();
                if (find == null)
                    return null;
                return Convertion.ChatMessagesConvertor.ConvertToDtoList(find);
            }
        }
        
    }
}

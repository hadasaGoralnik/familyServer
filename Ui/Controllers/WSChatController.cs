using Bl;
using Dto.Interfaces;
using Dto.Models;
using Dto.Requests;
using Microsoft.AspNet.SignalR.WebSockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.WebSockets;

namespace Ui.Controllers
{
    public class WSChatController : ApiController
    {
        IChatService _service;
        public WSChatController(IChatService service)
        {
            _service = service;
        }

        int currentGroup;
        int currentUser;
        [HttpGet]
        [Route("api/WSChat/Get/{GroupId}/{userId}")]
        public HttpResponseMessage Get(int GroupId, int userId)
        {
            currentGroup = GroupId;
            currentUser = userId;
            if (HttpContext.Current.IsWebSocketRequest)
            {
                HttpContext.Current.AcceptWebSocketRequest(ProcessWSChat);
            }
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        [HttpPost]
        public IHttpActionResult addChatMessage(AddChatMessageRequest request)
        {

            ChatMessagesDto msg = ChatService.AddChatMessage(request);
            if (msg == null)
                return BadRequest();
            if (msg != null)
                return Ok(msg);
            return BadRequest();
        }

        [HttpGet]
        [Route("api/WSChat/GetMessages/{GroupId}")]

        public IHttpActionResult GetMessages(int GroupId)
        {
            return Ok(ChatService.GetMessages(GroupId));
        }
        private async Task ProcessWSChat(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            if (!_service.websockets.ContainsKey(currentGroup))
            {
                _service.websockets[currentGroup] = new Dictionary<int, WebSocket>();
            }
            _service.websockets[currentGroup][currentUser] = socket;
            while (true)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await socket.ReceiveAsync(
                    buffer, CancellationToken.None);
                if (socket.State == WebSocketState.Open)
                {
                    string userMessage = Encoding.UTF8.GetString(
                        buffer.Array, 0, result.Count);
                    SendMessageRequest request = JsonConvert.DeserializeObject<SendMessageRequest>(userMessage);
                    currentUser = int.Parse(request.userId);
                    foreach (var s in _service.websockets[request.GroupId])
                    {

                        var time = DateTime.Now;
                            userMessage = request.userId+"-"+request.msg+"-"+request.GroupId+"-"+ time.ToString();
                            buffer = new ArraySegment<byte>(
                            Encoding.UTF8.GetBytes(userMessage));
                            await s.Value.SendAsync(
                            buffer, WebSocketMessageType.Text, true, CancellationToken.None);
  
                    }

                }
                else
                {
                    _service.websockets[currentGroup].Remove(currentUser);
                    break;
                    
                }
            }
        }
    }
}

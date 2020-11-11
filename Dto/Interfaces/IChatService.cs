using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Interfaces
{
    public interface IChatService
    {
        Dictionary<int, Dictionary<int, WebSocket>> websockets { get; set; }
    }
}

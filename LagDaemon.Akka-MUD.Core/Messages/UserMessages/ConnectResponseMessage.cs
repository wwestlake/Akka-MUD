using Akka.Configuration.Hocon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.Messages.UserMessages
{

    public class ConnectResponseMessage : MessageBase
    {
        public ConnectResponseMessage(string details) 
        {
            Details = details;
        }

        public string Details { get; }
    }

    public class ConnectionApprovedMessage : ConnectResponseMessage 
    {
        public Guid Token { get; }

        public ConnectionApprovedMessage() : base("Connection Approved")
        {
            Token = Guid.NewGuid();
        }
    }

    public class ConnectionRefusedMessage : ConnectResponseMessage 
    {
        public ConnectionRefusedMessage(string detail) : base(detail)
        {
            
        }
    }
}

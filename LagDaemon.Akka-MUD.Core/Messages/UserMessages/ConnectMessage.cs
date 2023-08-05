using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.Messages.UserMessages
{
    public class ConnectMessage : MessageBase
    {
        public ConnectMessage(string accountId, string password) 
        {
            AccountId = accountId;
            Password = password;
        }

        public string AccountId { get; }
        public string Password { get; }
    }
}

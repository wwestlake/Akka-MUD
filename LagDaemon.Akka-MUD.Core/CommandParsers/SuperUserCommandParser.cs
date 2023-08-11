using Akka.Actor;
using LagDaemon.Akka_MUD.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.CommandParsers
{
    public class SuperUserCommandParser : AdminCommandParser
    {
        public SuperUserCommandParser(IActorRef actor, IAccountServices accountServices, string prompt = "MUD> ") : base(actor,accountServices, prompt)
        {
        }
    }
}

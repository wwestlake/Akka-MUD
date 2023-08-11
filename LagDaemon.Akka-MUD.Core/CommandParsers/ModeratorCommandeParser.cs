using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.CommandParsers
{
    public class ModeratorCommandeParser : UserCommandParser
    {
        public ModeratorCommandeParser(IActorRef actor, string prompt = "MUD> ") : base(actor, prompt)
        {
        }
    }
}

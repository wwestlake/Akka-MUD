using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.Messages.SystemMessages
{
    public class CommandParserError
    {
        public object Item { get; set; }
        public string Message { get; set; }
    }
}

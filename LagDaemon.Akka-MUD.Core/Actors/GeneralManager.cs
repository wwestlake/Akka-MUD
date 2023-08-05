using Akka.Actor;
using Akka.Event;
using LagDaemon.Akka_MUD.Core.Messages.UserMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.Actors
{
    public class GeneralManager : ReceiveActor
    {
        private readonly ILoggingAdapter log = Context.GetLogger();

        public GeneralManager()
        {
            Receive<RequestAccountMessage>(message => { 
                
            });             
        }

    }
}

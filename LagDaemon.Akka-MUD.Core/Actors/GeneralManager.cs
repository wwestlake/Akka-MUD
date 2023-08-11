using Akka.Actor;
using Akka.Event;
using FluentResults;
using LagDaemon.Akka_MUD.Core.Messages.SystemMessages;
using LagDaemon.Akka_MUD.Core.Messages.UserMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.Actors
{
    public class GeneralManager : ReceiveActor, ILogReceive
    {
        protected readonly TimeSpan _timeDelay = TimeSpan.FromSeconds(5);
        protected readonly ILoggingAdapter log = Context.GetLogger();

        protected readonly HashSet<IActorRef> _clients = new();

        public GeneralManager()
        {
            Receive<PingMessage>(message => {
                log.Info("PING");
                Sender.Tell(new PongMessage());
            });

            Receive<PongMessage>(message => {
                log.Info("PONG");
            });

            Receive<ConnectMessage>(message =>
            {
                _clients.Add(Sender);

            });


        }



    }
}

using Akka.Actor;
using Akka.Configuration;
using LagDaemon.Akka_MUD.Core.Actors;
using LagDaemon.Akka_MUD.Core.Messages.SystemMessages;
using System.Net.NetworkInformation;

namespace LagDaemon.Akk_MUD.Server
{
    public class MUDServer
    {

        public class MUDServerActor : GeneralManager
        {
            public MUDServerActor() : base() { }
        }

        public static async Task Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(@"
akka {
    actor {
        provider = remote
    }
    remote {
        dot-netty.tcp {
            port = 8081
            hostname = 127.0.0.1
            public-hostname = localhost
        }
    }
}
");

            var system = ActorSystem.Create("MUDServer", config);
            var chatClient = system.ActorOf(Props.Create(() => new MUDServerActor()), "MUDServer");
            //chatClient.Tell(new PingMessage());
            Console.ReadLine();

            await system.Terminate();
        }
    }


}

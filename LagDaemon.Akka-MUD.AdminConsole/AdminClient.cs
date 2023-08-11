using Akka.Actor;
using LagDaemon.Akka_MUD.Core.Actors;
using LagDaemon.Akka_MUD.Core.Messages.SystemMessages;
using LagDaemon.Akka_MUD.Core.Storage;

namespace LagDaemon.Akka_MUD.AdminConsole
{
    public class AdminClient : GeneralManager
    {
        //[INFO][08/06/2023 01:25:41.433Z][Thread 0001][remoting (akka://MUDServer)] Remoting now listens on addresses: [akka.tcp://MUDServer@localhost:8081]
        private readonly ActorSelection _server =
           Context.ActorSelection("akka.tcp://MUDServer@localhost:8081/user/MUDServer");

        public AdminClient() : base() 
        {
            Receive<StartMessage>(sm => {
                _server.Tell(new PingMessage());
            });

            Receive<ClientExitMessage>(cem => {
                _server.Tell(cem);
                
            });

            Receive<CommandParserError>(cpe => {
                Console.WriteLine();
                Console.WriteLine($"Error: {cpe.Message}");
                Console.WriteLine();
            });
        }
    }

    public class StartMessage : MessageBase
    {
    }
}

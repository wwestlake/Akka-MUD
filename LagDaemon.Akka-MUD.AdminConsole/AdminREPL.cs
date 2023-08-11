using Akka.Actor;
using LagDaemon.Akka_MUD.Core.CommandParsers;
using LagDaemon.Akka_MUD.Core.Messages.SystemMessages;
using LagDaemon.Akka_MUD.Core.Messages.UserMessages;
using LagDaemon.Akka_MUD.Core.Model;
using LagDaemon.Akka_MUD.Core.Services;
using LagDaemon.Akka_MUD.Core.Storage;

namespace LagDaemon.Akka_MUD.AdminConsole
{
    public class AdminREPL
    {
        private readonly IActorRef _actor;
        private readonly IAccountServices _accountService;
        private AdminCommandParser _parser;

        public AdminREPL(IActorRef actor, IAccountServices accountService)
        {
            _actor = actor;
            _accountService = accountService;
            _parser = new AdminCommandParser(actor, accountService, "admin> ");
        }

        public async Task Run()
        {
            await Task.Run(() => {
                _parser.Repl();
            });
        }

 

    }
}

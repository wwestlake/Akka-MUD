using Akka.Actor;
using Akka.Util.Internal;
using LagDaemon.Akka_MUD.Core.Services;
using Pyratron.Frameworks.Commands.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.CommandParsers
{
    public class AdminCommandParser : ModeratorCommandeParser
    {
        protected readonly IAccountServices _accountService;

        public AdminCommandParser(IActorRef actor, IAccountServices accountService, string prompt = "MUD> ") : base(actor, prompt)
        {
            _parser.AddCommand(Command
                .Create("Add User")
                .AddAlias("adduser")
                .AddAlias("au")
                .SetDescription("Add a new user to the system")
                .AddArgument(Argument.Create("UserName"))
                .AddArgument(Argument.Create("Password"))
                .AddArgument(Argument.Create("EmailAddress"))
                .AddArgument(Argument.Create("DisplayName"))
                .SetAction((args, o) => {
                    _accountService.CreateAccount(args.FromName("UserName"), 
                        args.FromName("Password"), 
                        args.FromName("EmailAddress"), 
                        args.FromName("DisplayName"), 
                        Model.UserPrivilageLevel.Player); 
                })
            );

            _parser.AddCommand(Command
                .Create("List Users")
                .AddAlias("listusers")
                .AddAlias("lu")
                .SetDescription("Lists users of the system")
                .SetAction(async (args, o) => {
                    var accounts = await _accountService.GetAccounts();
                    if (accounts.IsSuccess)
                    {
                        Console.WriteLine();
                        foreach (var account in accounts.Value)
                        {
                            Console.WriteLine(account.ToString());
                            System.ReadLine.Send("\n");
                        }
                    }
                })
            );

            _accountService = accountService;
        }
    }
}

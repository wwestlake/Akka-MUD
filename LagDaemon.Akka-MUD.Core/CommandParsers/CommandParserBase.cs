using Akka.Actor;
using LagDaemon.Akka_MUD.Core.Messages.SystemMessages;
using Pyratron.Frameworks.Commands.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.CommandParsers
{
    public class CommandParserBase
    {
        protected IActorRef _actor;
        private string _prompt;
        protected CommandParser _parser;
        protected bool _replRunning = false;

        public CommandParserBase(IActorRef actor, string prompt = "MUD> ")
        {
            _actor = actor;
            _prompt = prompt;
            _parser = CommandParser.CreateNew().UsePrefix("/").OnError( (o,s) => {
                // send error message to actor
                _actor.Tell(new CommandParserError { Item = o, Message = s });
            });

            _parser.AddCommand(Command
                .Create("Exit")
                .AddAlias("exit")
                .SetDescription("The actor will exit the game")
                .SetAction((args, o) => {
                    _actor.Tell(new ClientExitMessage { Message = args[0].ToString() ?? string.Empty });
                    _replRunning = false;
                })
                .AddArgument(Argument
                    .Create("Message")
                    .MakeOptional()
                    .SetDefault("So long, and thanks for all the fish!")
                    )
            );

            _parser.AddCommand(Command
                .Create("Help")
                .AddAlias("help")
                .SetDescription("Display helpful information")
                .SetAction((args, o) => { 
                    foreach (var cmd in _parser.Commands)
                    {
                        Console.WriteLine($"{cmd.Name} - {cmd.Description}\n\t{cmd.GenerateUsage()}");
                    }
                
                })
            );

        }

        public void Repl()
        {
            System.ReadLine.HistoryEnabled = true;
            _replRunning = true;
            while (_replRunning)
            {
                Console.Write(_prompt);
                var input = System.ReadLine.Read();
                _parser.Parse(input);
            }
        }

    }
}

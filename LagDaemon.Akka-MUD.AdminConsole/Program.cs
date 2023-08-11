


using Akka.Actor;
using Akka.Configuration;
using Akka.DI.CastleWindsor;
using Akka.DI.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using LagDaemon.Akka_MUD.AdminConsole;
using LagDaemon.Akka_MUD.Core.IoC;

var config = ConfigurationFactory.ParseString(@"
akka {  
    actor {
        provider = remote
    }
    remote {
        dot-netty.tcp {
		    port = 0
		    hostname = localhost
        }
    }
}
");

var container = new WindsorContainer();
container.Install(new MUDCoreInstaller());
container.Install(new AdminConsoleInstaller());


using (var system = ActorSystem.Create("AdminClient", config))
{
    IDependencyResolver resolver = new WindsorDependencyResolver(container, system);

    var chatClient = system.ActorOf(resolver.Create<AdminClient>());
    container.Register(Component.For<IActorRef>().Instance(chatClient));
    var repl = container.Resolve<AdminREPL>();
    await repl.Run();

    await system.Terminate();
}















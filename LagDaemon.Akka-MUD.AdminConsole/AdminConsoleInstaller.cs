using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace LagDaemon.Akka_MUD.AdminConsole
{
    public class AdminConsoleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<AdminClient>().ImplementedBy<AdminClient>(),
                Component.For<AdminREPL>().ImplementedBy<AdminREPL>()
            );
        }
    }
}

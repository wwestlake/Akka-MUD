using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LagDaemon.Akka_MUD.Core.Services;
using LagDaemon.Akka_MUD.Core.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.IoC
{
    public class MUDCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IDataContext<>)).ImplementedBy(typeof(DataContext<>)),
                Component.For<IAccountServices>().ImplementedBy<AccountServices>()
            );
        }
    }
}

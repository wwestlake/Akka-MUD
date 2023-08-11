using LagDaemon.Akka_MUD.Core.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.UnitTests
{
    public class TestBase<T>
    {
        protected DataContext<T> dataContext = new DataContext<T>(new MemoryStream());

        public TestBase()
        {
            
        }
    }
}

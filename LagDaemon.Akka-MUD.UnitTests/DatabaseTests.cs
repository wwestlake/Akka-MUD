using FluentAssertions;
using LagDaemon.Akka_MUD.Core.Model;
using LagDaemon.Akka_MUD.Core.Storage;

namespace LagDaemon.Akka_MUD.UnitTests
{

    public class DatabaseTests : TestBase<UserAccount>
    {
        public DatabaseTests() : base()
        {

        }

        [Fact]
        public void Insert_With_AutoId()
        {
            var u1 = new UserAccount { Name = "John" };
            var u2 = new UserAccount { Name = "Zarlos" };
            var u3 = new UserAccount { Name = "Ana" };

            dataContext.Insert(new UserAccount[] { u1, u2, u3 });

            u1.Id.Should().NotBeEmpty();
            u2.Id.Should().NotBeEmpty();
            u3.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void DataContex_returns_query_for_all_items_of_type_T()
        {
            var u1 = new UserAccount { Name = "John" };
            var u2 = new UserAccount { Name = "Zarlos" };
            var u3 = new UserAccount { Name = "Ana" };

            dataContext.Insert(new UserAccount[] { u1, u2, u3 });
            var query = dataContext.Query();
            var count = query?.Count();
            var ana = query?.Where(x => x.Name == "Ana");

            query.Should().NotBeNull();
            count.Should().Be(3);
            ana.Should().NotBeNull();
            ana?.Count().Should().Be(1);
            ana?.FirstOrDefault().Name.Should().Be("Ana");
        }

        [Fact]
        public void DataContext_returns_users_based_on_privs()
        {
            var u1 = new UserAccount { Name = "John", PrivilageLevel = UserPrivilageLevel.Player };
            var u2 = new UserAccount { Name = "Zarlos", PrivilageLevel = UserPrivilageLevel.Player };
            var u3 = new UserAccount { Name = "Ana", PrivilageLevel = UserPrivilageLevel.Owner };
            dataContext.Insert(new UserAccount[] { u1, u2, u3 });

            var list = dataContext?.Query()?.Where(x => x.PrivilageLevel == UserPrivilageLevel.Player).ToList();

            list.Should().NotBeNull();
            list?.Count.Should().Be(2);
        }


    }
}

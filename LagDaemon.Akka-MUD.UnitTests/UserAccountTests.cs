using FluentAssertions;
using LagDaemon.Akka_MUD.Core.Model;
using LagDaemon.Akka_MUD.Core.Services;
using LagDaemon.Akka_MUD.Core.Utilities;

namespace LagDaemon.Akka_MUD.UnitTests
{
    public class UserAccountTests : TestBase<UserAccount>
    {

        protected IAccountServices _service;

        public UserAccountTests()
        {
            _service = new AccountServices(dataContext);
        }

        [Fact]
        public async Task CreateUserAccount_saves_a_new_user_and_returns_the_user_id_guid()
        {
            var guid = await _service.CreateAccount("test", "test", "test@tester.com", "tester", UserPrivilageLevel.Player);
            guid.IsSuccess.Should().BeTrue();

            var newUser = await _service.Get(guid.Value);
            newUser.Should().NotBeNull();
            newUser.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task CreateUserAccount_properly_hashes_the_password()
        {
            var guid = await _service.CreateAccount("test", "test", "test@tester.com", "tester", UserPrivilageLevel.Player);
            guid.IsSuccess.Should().BeTrue();

            var newUser = await _service.Get(guid.Value);
            newUser.Should().NotBeNull();

            CryptoFunctions.VerifyPassword("test", newUser.Value.Password)
                .Should().BeTrue();

            CryptoFunctions.VerifyPassword("test1", newUser.Value.Password)
                .Should().BeFalse();

        }

    }
}
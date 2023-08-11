using FluentResults;
using LagDaemon.Akka_MUD.Core.Model;

namespace LagDaemon.Akka_MUD.Core.Services
{
    public interface IAccountServices
    {
        Task<Result<Guid>> CreateAccount(string username, string password, string email, string displayName, UserPrivilageLevel level);
        Task<Result<UserAccount>> Get(Guid id);
        Task<Result<IEnumerable<UserAccount>>> GetAccounts();
    }
}
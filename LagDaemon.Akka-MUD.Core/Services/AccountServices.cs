using Akka.Util;
using LagDaemon.Akka_MUD.Core.Model;
using LagDaemon.Akka_MUD.Core.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FR = FluentResults;

namespace LagDaemon.Akka_MUD.Core.Services
{
    public class AccountServices : IAccountServices
    {
        private IDataContext<UserAccount> _context;

        public AccountServices(IDataContext<UserAccount> context)
        {
            this._context = context;
        }

        public async Task<FR.Result<IEnumerable<UserAccount>>> GetAccounts()
        {
            return await Task.Run(() =>
            {
                var result = _context.Query()?.ToList().AsEnumerable() ?? new List<UserAccount>().AsEnumerable();
                if (result.Count() == 0)
                {
                    return FR.Result.Fail("No accounts found");
                }
                return FR.Result.Ok(result);
            });
        }

        // TODO: Better account creation?
        public async Task<FR.Result<Guid>> CreateAccount(string username, string password, string email, string displayName, UserPrivilageLevel level)
        {
            return await Task.Run(() =>
            {
                var hashedPassword = Utilities.CryptoFunctions.HashPassword(password);
                var result = _context.Insert(new UserAccount { Name = username, Password = hashedPassword, EmailAddress = email, DisplayName = displayName, PrivilageLevel = level, AccountStatus = AccountStatus.Normal });
                if (result == null)
                {
                    return FR.Result.Fail("Unable to create account");
                }
                return FR.Result.Ok((Guid)result);
            });
        }

        public async Task<FR.Result<UserAccount>> Get(Guid id)
        {
            return await Task.Run(() =>
            {
                var result = _context.Query()?.Where(acc => acc.Id == id).FirstOrDefault();
                if (result == null) return FR.Result.Fail("Account Id not found");
                return FR.Result.Ok(result);
            });
        }





    }
}

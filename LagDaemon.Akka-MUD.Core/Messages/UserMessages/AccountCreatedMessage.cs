
namespace LagDaemon.Akka_MUD.Core.Messages.UserMessages {
    public class AccountCreatedMessage : MessageBase {

        public string AccountId { get; private set; }
        public string TempPassword { get; private set; }
        public AccountCreatedMessage(string accountId, string tempPassword)
        {
            AccountId = accountId;
            TempPassword = tempPassword;
        }
    }
}


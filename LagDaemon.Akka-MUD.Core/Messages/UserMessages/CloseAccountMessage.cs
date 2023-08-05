namespace LagDaemon.Akka_MUD.Core.Messages.UserMessages {

    public class CloseAccountMessage : MessageBase {

        public string AccountId { get; private set; }
        public string Password { get; private set; }

        public CloseAccountMessage(string accountId, string password)
        {
            AccountId = accountId;
            Password = password;
        }
    }
}
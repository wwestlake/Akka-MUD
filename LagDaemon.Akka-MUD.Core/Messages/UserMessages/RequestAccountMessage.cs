namespace LagDaemon.Akka_MUD.Core.Messages.UserMessages {
    public class RequestAccountMessage : MessageBase 
    {
        public string AccountId { get; private set; }
        public string Email {get; private set;}
        public string DisplayName { get; set;}
        
        public RequestAccountMessage(string accountId, string email, string displayName)
        {
            AccountId = accountId;
            Email = email;
            DisplayName = displayName;
        }
    }
}
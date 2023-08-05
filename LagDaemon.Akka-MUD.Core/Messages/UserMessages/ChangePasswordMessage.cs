namespace LagDaemon.Akka_MUD.Core.Messages.UserMessages {

    public class ChangePasswordMessage : MessageBase {
        public Guid Token { get; }
        public string OldPassword { get; private set; }
        public string NewPassword { get; private set;}

        public ChangePasswordMessage(Guid token, string oldPassword, string newPassword) 
        {
            Token = token;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }

}
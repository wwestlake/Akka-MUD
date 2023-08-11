using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.Model
{
    public class UserAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public UserPrivilageLevel PrivilageLevel { get; set; }
        public AccountStatus AccountStatus { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Name           :  {Name}");
            builder.AppendLine($"Display Name   :  {DisplayName}");
            builder.AppendLine($"Email Address  :  {EmailAddress}");
            builder.AppendLine($"Hashed Password:  {Password}");
            builder.AppendLine($"Privilage Level:  {PrivilageLevel}");
            builder.AppendLine($"Account Status :  {AccountStatus}");
            return builder.ToString();
        }

    }
}

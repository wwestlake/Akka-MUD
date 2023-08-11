using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.Model
{
    public enum UserPrivilageLevel
    {
        None = 0,
        Player = 1,
        Moderator = 2,
        AssistantAdmin = 3,
        Admin = 4,
        Owner = 5,
    }

    public enum AccountStatus
    {
        Normal = 0,
        Restricted = 1,
        Banned = 2,
        Locked = 3,
    }

}

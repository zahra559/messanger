using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeMessanger.Models
{
 
    public class AppUser : IdentityUser
    {
        // 1 => * AppUser => Message
        public AppUser()
        {
            Notis = new HashSet<Noti>();
            Messages = new HashSet<Message>();
        }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Noti> Notis { get; set; }
    }
}

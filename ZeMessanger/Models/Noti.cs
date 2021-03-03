using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeMessanger.Models
{
    public class Noti
    {
        public int NotiId { get; set; } = 0;
    
        public string NotiHeader { get; set; } = "";
        public string NotiBody { get; set; } = "";
        public bool IsRead { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UserID { get; set; }
        public string CreatedDateSt => this.CreatedDate.ToString("dd-MMM-yyyy HH:mm:ss");
        public string IsReadSt => this.IsRead ? "YES" : "NO";
        public virtual AppUser Sender { get; set; }
        public string FromUserName { get; set; } = "";
        public string ToUserName { get; set; } = "";
    }
}

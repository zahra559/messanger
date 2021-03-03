using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeMessanger.Data;
using ZeMessanger.IService;
using ZeMessanger.Models;

namespace ZeMessanger.Service
{

    public class NotiService : INotiService
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<AppUser> _userManger;
        public NotiService(ApplicationDbContext context, UserManager<AppUser> userManger)
        {
            _userManger = userManger;
            _context = context;
        }

        List<Noti> _oNotifications = new List<Noti>();
        public List<Noti> GetNotifications(string nToUser, bool bIsGetOnlyUnread)
        {
            _oNotifications = new List<Noti>();

            var oNotis = _context.Notis.Where(a => a.ToUserName == nToUser).ToList();
            if (oNotis != null && oNotis.Count() > 0)
            {
                _oNotifications = oNotis;
            }
            return _oNotifications;
        }
    }
}

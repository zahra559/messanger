using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeMessanger.Models;

namespace ZeMessanger.IService
{
    public interface INotiService
    {
        List<Noti> GetNotifications(string nToUser, bool bIsGetOnlyUnread);
    }
}

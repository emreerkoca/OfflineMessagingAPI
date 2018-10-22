using OfflineMessagingAPI.Helpers;
using OfflineMessagingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfflineMessagingAPI.Services
{
    public interface ICustomUserServices
    {
        CustomUser CreateCustomUser(CustomUser customUser);
        CustomUser LoginCustomUser(LoginInfo loginInfo);
        CustomUser IsOnline(string customUserName);
        bool SendMessage(MessageInfo messageInfo);
        List<List<Messages>> GetAllChats(int customUserId);
        ActivityLogs InsertActivityLog(ActivityLogs activityLog);
        void InsertPublicLog(PublicLogs publicLog);
        void BlockUser(BlockUser blockUser);
    }
}

using OfflineMessagingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfflineMessagingAPI.Helpers
{
    public class UsersAllChatsHelper
    {
        public List<List<Messages>> AllChats { get; set; }

        public UsersAllChatsHelper()
        {
            AllChats = new List<List<Messages>>();
        }

    }
}

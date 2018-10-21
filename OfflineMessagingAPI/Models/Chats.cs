using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfflineMessagingAPI.Models
{
    public class Chats
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime SenderDeleteTime { get; set; }
        //if user is delete chat, delete time is updated. 
        //user can' t see messages before deletion time.
        public DateTime ReceiverDeleteTime { get; set; }
    }
}

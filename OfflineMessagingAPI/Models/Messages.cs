using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OfflineMessagingAPI.Models
{
    [Table("Messages")]
    public class Messages : BaseEntity
    {
        [Required]
        public int SenderId { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public string MessageContent { get; set; }

        //public string sentTime {get; set;} //Base Entity UploadDate = Sent Time        

        [Required]
        public DateTime TransmissionTime { get; set; }

        [Required]
        public bool IsMessageReached { get; set; }

        [Required]
        public bool IsMessageSeen { get; set; }

    }
}

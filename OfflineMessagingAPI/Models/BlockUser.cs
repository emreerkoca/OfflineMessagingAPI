using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OfflineMessagingAPI.Models
{
    [Table("BlockUser")]
    public class BlockUser
    {
        public int Id { get; set; }

        public virtual CustomUser BlockerUser { get; set; }

        public virtual CustomUser BlockedUser { get; set; }

        public DateTime BlockedDate { get; set; }

    }
}

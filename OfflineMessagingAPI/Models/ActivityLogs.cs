using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OfflineMessagingAPI.Models
{
    [Table("ActivityLogs")]
    public class ActivityLogs
    {
        public int Id { get; set; }

        public string ActivityContent { get; set; }

        public string ActivityTime { get; set; }
    }
}

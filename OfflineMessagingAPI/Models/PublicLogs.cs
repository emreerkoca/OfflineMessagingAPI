using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OfflineMessagingAPI.Models
{
    [Table("PublicLogs")]
    public class PublicLogs
    {
        public int Id { get; set; }

        public string LogContent { get; set; }

        public DateTime LogTime { get; set; }
    }
}

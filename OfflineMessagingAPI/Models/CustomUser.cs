using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OfflineMessagingAPI.Models
{
    [Table("CustomUser")]
    public class CustomUser : BaseEntity
    {
         //BaseEntity contains Id, Upload Date and IsActive informations

        [MaxLength(50, ErrorMessage = "Max Length: 50 ")]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Max Length: 50 ")]
        [Required]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "Max Length: 50 ")]
        [Required]
        public string UserName { get; set; }

        [MaxLength(50, ErrorMessage = "Max Length: 50 ")]
        [Required]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "Max Length: 16 ")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public DateTime LastLoginTime { get; set; }

        public bool IsOnline { get; set; }
    }
}

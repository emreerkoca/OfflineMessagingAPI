using Microsoft.EntityFrameworkCore;
using OfflineMessagingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfflineMessagingAPI.DataContext
{
    public class OfflineMessagingDbContext : DbContext
    {
        public OfflineMessagingDbContext(DbContextOptions<OfflineMessagingDbContext> options) : base(options)
        {

        }


        DbSet<CustomUser> CustomUsers { get; set; }
        DbSet<Messages> Messages { get; set; }
        DbSet<ActivityLogs> ActivityLogs { get; set; }
        DbSet<BlockUser> BlockUser { get; set; }
        DbSet<PublicLogs> PublicLogs { get; set; }
    }
}

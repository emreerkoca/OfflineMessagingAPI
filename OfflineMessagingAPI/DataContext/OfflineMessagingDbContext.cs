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

        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<ActivityLogs> ActivityLogs { get; set; }
        public DbSet<BlockUser> BlockUser { get; set; }
        public DbSet<PublicLogs> PublicLogs { get; set; }
        public DbSet<Chats> Chats { get; set; }
    }
}

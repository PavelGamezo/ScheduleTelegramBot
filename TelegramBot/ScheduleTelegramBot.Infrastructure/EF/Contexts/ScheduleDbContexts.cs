using Microsoft.EntityFrameworkCore;
using ScheduleTelegramBot.Domain.AppUser.Entities;
using ScheduleTelegramBot.Domain.Tasks.Entities;
using ScheduleTelegramBot.Infrastructure.EF.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Infrastructure.EF.Contexts
{
    public sealed class ScheduleDbContexts : DbContext
    {
        public ScheduleDbContexts(DbContextOptions options) : base(options)
        {
        }
            
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppUserTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var appUserConfiguration = new AppUserDbConfiguration();
            var appUserTaskConfiguration = new AppUserTaskDbConfiguration();

            modelBuilder.ApplyConfiguration(appUserConfiguration);
            modelBuilder.ApplyConfiguration(appUserTaskConfiguration);

            base.OnModelCreating(modelBuilder);
        }
    }
}

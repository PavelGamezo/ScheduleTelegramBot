using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleTelegramBot.Domain.Tasks.Entities;

namespace ScheduleTelegramBot.Infrastructure.EF.Configurations
{
    internal class AppUserTaskDbConfiguration : IEntityTypeConfiguration<AppUserTask>
    {
        public void Configure(EntityTypeBuilder<AppUserTask> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(task => task.Id);
        }
    }
}

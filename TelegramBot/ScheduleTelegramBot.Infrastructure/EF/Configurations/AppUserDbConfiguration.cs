using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleTelegramBot.Domain.AppUser.Entities;

namespace ScheduleTelegramBot.Infrastructure.EF.Configurations
{
    internal class AppUserDbConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser");
            builder.HasKey(user => user.Id);

            builder
                .HasMany(user => user.Tasks)
                .WithOne(task => task.User);
        }
    }
}

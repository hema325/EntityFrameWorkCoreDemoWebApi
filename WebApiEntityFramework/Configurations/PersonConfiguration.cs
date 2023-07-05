using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasMany(p => p.SendedMessages).WithOne(p => p.Sender).OnDelete(DeleteBehavior.Restrict).HasForeignKey(m=>m.SenderId);
            builder.HasMany(p => p.ReceivedMessages).WithOne(p => p.Receiver).OnDelete(DeleteBehavior.Restrict).HasForeignKey(m=>m.ReceiverId);
        }
    }
}

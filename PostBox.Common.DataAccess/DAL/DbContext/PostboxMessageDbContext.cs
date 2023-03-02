using Microsoft.EntityFrameworkCore;
using PostBox.Common.Core;

namespace PostBox.Common.DataAccess.DAL
{
    public class PostboxMessageDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PostboxMessagesDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostboxMessage>().Ignore(p => p.BrokerSpecificHeaders);
            modelBuilder.Entity<PostboxMessage>().Ignore(p => p.CustomHeaders);
            modelBuilder.Entity<PostboxMessage>().Ignore(p => p.PostboxHeaders);
            modelBuilder.Entity<PostboxMessage>().Ignore(p => p.DeliveryParameters);
            modelBuilder.Entity<PostboxMessage>().HasKey(p => p.Id);


        }

        public DbSet<PostboxMessage> Messages { get; set; }
    }
}

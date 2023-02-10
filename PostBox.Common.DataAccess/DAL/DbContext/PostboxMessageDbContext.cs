using Microsoft.EntityFrameworkCore;
using PostBox.Common.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostBox.Common.DataAccess.DAL
{
    public class PostboxMessageDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PostboxMessagesDB");
        }
        public DbSet<PostboxMessage> Messages { get; set; }
    }
}

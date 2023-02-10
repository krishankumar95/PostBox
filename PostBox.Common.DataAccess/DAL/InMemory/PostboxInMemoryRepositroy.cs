using Microsoft.EntityFrameworkCore.ChangeTracking;
using PostBox.Common.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostBox.Common.DataAccess.DAL.InMemory
{
    public class PostboxInMemoryRepositroy : IPostboxMessageRepository<PostboxMessage>
    {
        private readonly PostboxMessageDbContext _dbContext;

        public PostboxInMemoryRepositroy(PostboxMessageDbContext dbContext) => _dbContext = dbContext;

        public async Task PublishMessage(PostboxMessage message)
        {
            await _dbContext.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }
    }
}

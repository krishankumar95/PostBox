using Microsoft.EntityFrameworkCore;
using PostBox.Common.Core;

namespace PostBox.Common.DataAccess.DAL.InMemory
{
    public class PostboxInMemoryRepositroy : IPostboxMessageRepository
    {
        private readonly PostboxMessageDbContext _dbContext = new PostboxMessageDbContext();

       // public PostboxInMemoryRepositroy(PostboxMessageDbContext dbContext) => _dbContext = dbContext;

        public async Task CreateMessage(PostboxMessage message)
        {
            await _dbContext.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }

        IEnumerable<PostboxMessage> IPostboxMessageRepository.GetAllMessages()
        {
            return _dbContext.Messages.ToList();
        }

       
    }
}

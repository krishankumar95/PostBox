using PostBox.Common.Core;

namespace PostBox.Common.DataAccess.DAL.InMemory
{
    public class PostboxInMemoryRepositroy : IPostboxMessageRepository
    {
        private readonly PostboxMessageDbContext _dbContext = new PostboxMessageDbContext();

        public PostboxInMemoryRepositroy()
        {
        }

       // public PostboxInMemoryRepositroy(PostboxMessageDbContext dbContext) => _dbContext = dbContext;

        public async Task CreateMessage(PostboxMessage message)
        {
            await _dbContext.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<PostboxMessage> GetAllMessages()
        {
            return _dbContext.Messages.ToList();
        }

        public PostboxMessage GetMessageWithId(string Id)
        {
            return GetAllMessages().Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }


       
    }
}

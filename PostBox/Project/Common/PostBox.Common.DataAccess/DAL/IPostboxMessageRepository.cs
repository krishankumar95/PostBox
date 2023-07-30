using PostBox.Common.Core;

namespace PostBox.Common.DataAccess.DAL
{
    public interface IPostboxMessageRepository
    {
        Task CreateMessage(PostboxMessage message);

        IEnumerable<PostboxMessage> GetAllMessages();

        PostboxMessage GetMessageWithId(string Id);
    }
}

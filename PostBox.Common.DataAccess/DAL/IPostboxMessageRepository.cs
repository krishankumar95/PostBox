using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostBox.Common.DataAccess.DAL
{
    public interface IPostboxMessageRepository<T>
    {
        Task PublishMessage(T message);
    }
}

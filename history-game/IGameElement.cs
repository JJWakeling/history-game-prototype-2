using System.Collections.Generic;
using System.Threading.Tasks;

namespace history_game
{
    public interface IGameElement
    {
        void QueueMessage(IMessage message);
        Task ProcessMessages();
        Task SendMessages(IEnumerable<IGameElement> elements);
    }
}

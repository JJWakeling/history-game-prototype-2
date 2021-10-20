using System.Collections.Generic;

namespace history_game
{
    public interface IHypermnesiacMessageQueue : IMessageQueue
    {
        IEnumerable<IMessage> ArchivedMessages();
    }
}

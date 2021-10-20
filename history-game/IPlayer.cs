using System.Collections.Generic;

namespace history_game
{
    //TODO: see if you can re-architect solution so players need not implement so many methods
    public interface IPlayer : ICharacter
    {
        IEnumerable<IMessage> MessagesSent();
        IEnumerable<IMessage> MessagesProcessed();
        void QueueOutgoingMessage(IMessage message);
    }
}

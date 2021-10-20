namespace history_game
{
    public interface IMessageQueue
    {
        void Queue(IMessage message);
        IMessage Pop();
    }
}

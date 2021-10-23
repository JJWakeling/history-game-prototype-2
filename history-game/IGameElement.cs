using System.Collections.Generic;

namespace history_game
{
    public interface IGameElement
    {
        long Id();
        void Execute(IProcess process);
        IEnumerable<IProcess> OutgoingProcesses();
    }
}

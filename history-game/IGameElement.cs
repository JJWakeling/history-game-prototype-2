using System.Collections.Generic;

namespace history_game
{
    ///<remarks>every IGameElementIdentifier can be used to look up an object with this interface</remarks>
    public interface IGameElement : IGameElementIdentifier
    {
        void Execute(IProcess process);
        IEnumerable<IProcess> OutgoingProcesses();
    }
}

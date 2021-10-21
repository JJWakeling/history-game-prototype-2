using System.Collections.Generic;
using System.Threading.Tasks;

namespace history_game
{
    public interface IProcessManager
    {
        /// <returns>id of the IGameElement this manages messages for</returns>
        long ElementId();
        void Enqueue(IProcess process);
        Task ExecuteProcesses();
        Task SendProcesses(IEnumerable<IProcessManager> processManagers);
    }
}

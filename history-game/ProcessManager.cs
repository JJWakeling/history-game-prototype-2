using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace history_game
{
    public class ProcessManager : IProcessManager
    {
        private readonly IGameElement _element;
        private readonly Queue<IProcess> _incomingProcesses;

        public ProcessManager(IGameElement element, Queue<IProcess> incomingProcesses)
        {
            _element = element;
            _incomingProcesses = incomingProcesses;
        }

        public ProcessManager(IGameElement element)
            : this(element, new Queue<IProcess>())
        {
        }

        public long ElementId()
        {
            return _element.Id();
        }

        public void Enqueue(IProcess process)
        {
            _incomingProcesses.Enqueue(process);
        }

        public Task ExecuteProcesses()
        {
            while (_incomingProcesses.Any())
            {
                _element.Execute(_incomingProcesses.Dequeue());
            }

            return Task.CompletedTask;
        }

        public Task SendProcesses(IEnumerable<IProcessManager> processManagers)
        {
            foreach (var process in _element.OutgoingProcesses())
            {
                processManagers.First(m => m.ElementId() == process.ObjectId())
                    .Enqueue(process);
            }

            return Task.CompletedTask;
        }
    }
}

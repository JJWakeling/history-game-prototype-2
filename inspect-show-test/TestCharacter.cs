using ElegantCSharp;
using history_game;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace inspect_show_test
{
    ///<summary>
    /// fires off single batch of processes and awaits response
    ///</summary>
    internal class TestCharacter : IGameElement
    {
        private readonly long _id;
        private readonly ICollection<IProcess> _processesToSend;
        private readonly ILatch<IProcess> _firstReceivedProcess;

        public TestCharacter(long id, ICollection<IProcess> processesToSend)
        {
            _id = id;
            _processesToSend = processesToSend;
            _firstReceivedProcess = new Latch<IProcess>();
        }

        public void Execute(IProcess process)
        {
            if (!_firstReceivedProcess.Latched())
            {
                _firstReceivedProcess.Set(process);
            }
        }

        public long Id()
        {
            return _id;
        }

        public IEnumerable<IProcess> OutgoingProcesses()
        {
            var processes = new IProcess[_processesToSend.Count];
            _processesToSend.CopyTo(processes, 0);
            _processesToSend.Clear();

            return processes;
        }

        public Task<IProcess> FirstReceivedProcess()
        {
            return new Task<IProcess>(() =>
                {
                    while (!_firstReceivedProcess.Latched())
                    {
                        Thread.Sleep(100);
                    }
                    return _firstReceivedProcess.Value();
                }
            );
        }
    }
}

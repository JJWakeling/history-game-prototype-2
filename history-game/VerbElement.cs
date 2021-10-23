using System.Collections.Generic;

namespace history_game
{
    public class VerbElement : IGameElement
    {
        private readonly long _id, _typeId, _inspectId, _showId;
        private readonly ICollection<IProcess> _outgoingProcesses;

        public VerbElement(long id, long typeId, long inspectId, long showId, ICollection<IProcess> outgoingProcesses)
        {
            _id = id;
            _typeId = typeId;
            _inspectId = inspectId;
            _showId = showId;
            _outgoingProcesses = outgoingProcesses;
        }

        public void Execute(IProcess process)
        {
            if (process.VerbId() == _inspectId)
            {
                _outgoingProcesses.Add(new Process(_id, _showId, process.SubjectId(), new long[] { _typeId }));
            }
        }

        public long Id()
        {
            return _id;
        }

        public IEnumerable<IProcess> OutgoingProcesses()
        {
            //TODO: find way of making this copy process simpler or write one yourself
            var processes = new IProcess[_outgoingProcesses.Count];
            _outgoingProcesses.CopyTo(processes, 0);
            _outgoingProcesses.Clear();

            return processes;
        }
    }
}

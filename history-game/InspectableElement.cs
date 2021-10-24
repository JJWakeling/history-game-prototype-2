using System.Collections.Generic;
using System.Linq;

namespace history_game
{
    public class InspectableElement : IGameElement
    {
        private readonly long _id, _inspectId, _showId;
        private readonly IDictionary<long, IEnumerable<long>> _attributes;
        private readonly ICollection<IProcess> _outgoingProcesses;

        public InspectableElement(long id, long inspectId, long showId, IDictionary<long, IEnumerable<long>> attributes, ICollection<IProcess> outgoingProcesses)
        {
            _id = id;
            _inspectId = inspectId;
            _showId = showId;
            _attributes = attributes;
            _outgoingProcesses = outgoingProcesses;
        }

        public InspectableElement(long id, long inspectId, long showId, IDictionary<long, IEnumerable<long>> attributes)
            : this(id, inspectId, showId, attributes, new List<IProcess>())
        {
        }

        public void Execute(IProcess process)
        {
            //inspect requires that the object show the subject it holds for the specified attribute
            //TODO: put responsibility onto verbs for implementing their effects:
            // Elements should encapsulate a set of verbs and a set of attributes
            // for every process passed to an element, it should look up the verb in its verb table
            // then pass the verb's IEnumerable<IProcess> Execute(IProcess, IDictionary<long, IEnumerable<long>>) method
            // the received process and its internal dictionary of attributes
            // so the verb can update any necessary attributes and return any processes to send
            if (process.VerbId() == _inspectId)
            {
                _outgoingProcesses.Add(
                    new Process(
                        _id,
                        _showId,
                        process.SubjectId(),
                        new long[] { process.SecondaryObjectIds().ElementAt(0) }
                            .Concat(_attributes[process.SecondaryObjectIds().ElementAt(0)])
                    )
                );
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

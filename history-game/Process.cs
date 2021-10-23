using System.Collections.Generic;

namespace history_game
{
    public class Process : IProcess
    {
        private readonly long _subjectId, _verbId, _objectId;
        private readonly IEnumerable<long> _secondaryObjectIds;

        public Process(long subjectId, long verbId, long objectId, IEnumerable<long> secondaryObjectIds)
        {
            _subjectId = subjectId;
            _verbId = verbId;
            _objectId = objectId;
            _secondaryObjectIds = secondaryObjectIds;
        }

        public long ObjectId()
        {
            return _objectId;
        }

        public IEnumerable<long> SecondaryObjectIds()
        {
            return _secondaryObjectIds;
        }

        public long SubjectId()
        {
            return _subjectId;
        }

        public long VerbId()
        {
            return _verbId;
        }
    }
}

using System.Collections.Generic;

namespace history_game
{
    public class Process : IProcess
    {
        private readonly long _subjectId, _objectId;
        private readonly IVerb _verb;
        private readonly IEnumerable<long> _secondaryObjectIds;

        public Process(long subjectId, IVerb verb, long objectId, IEnumerable<long> secondaryObjectIds)
        {
            _subjectId = subjectId;
            _verb = verb;
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

        public IVerb Verb()
        {
            return _verb;
        }
    }
}

using System.Collections.Generic;

namespace history_game
{
    public interface IProcess
    {
        ///<returns>id of element that generated the process</returns>
        long SubjectId();
        ///<returns>id of element to send process to</returns>
        long ObjectId();
        ///<returns>defines what process does</returns>
        long VerbId();
        ///<returns>ids of elements relevant to the process, but not as subject/object</returns>
        IEnumerable<long> SecondaryObjectIds();
    }
}

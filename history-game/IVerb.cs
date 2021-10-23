using System.Collections.Generic;

namespace history_game
{
    ///<summary>
    /// defines the action of a process
    ///</summary>
    public interface IVerb : IGameElementIdentifier
    {
        bool ValidNextPartOfPhrase(IEnumerable<ICategory> previousParts, ICategory nextPart);
        bool MakesCompletePhrase(IEnumerable<ICategory> parts);
    }
}

using System.Collections.Generic;

namespace history_game
{
    ///<summary>
    /// defines the action of a process
    ///</summary>
    public interface IVerb : IGameElementIdentifier
    {
        bool ValidNextPartOfPhrase(IEnumerable<IType> previousParts, IType nextPart);
        bool MakesCompletePhrase(IEnumerable<IType> parts);
    }
}

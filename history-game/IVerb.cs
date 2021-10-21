using System.Collections.Generic;

namespace history_game
{
    public interface IVerb : IGameElementIdentifier
    {
        bool ValidNextPartOfPhrase(IEnumerable<IType> previousParts, IType nextPart);
        bool MakesCompletePhrase(IEnumerable<IType> parts);
    }
}

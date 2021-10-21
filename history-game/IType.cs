using System.Collections.Generic;

namespace history_game
{
    public interface IType : IGameElementIdentifier
    {
        ///<returns>id of this type as well as all more abstract types</returns>
        IEnumerable<long> SuperTypeIds();
    }
}

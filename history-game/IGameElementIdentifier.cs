namespace history_game
{
    ///<summary>
    /// provides access to the Id of an IGameElement, but not its Execute or OutgoingProcess methods
    ///</summary>
    public interface IGameElementIdentifier
    {
        ///<returns>id of wrapped element</returns>
        long Id();
    }
}

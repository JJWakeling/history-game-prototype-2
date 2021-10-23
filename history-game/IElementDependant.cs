namespace history_game
{
    ///<summary>
    /// object that relates to a particular IGameElement in some way
    ///</summary>
    public interface IElementDependant
    {
        long ElementId();
    }
}

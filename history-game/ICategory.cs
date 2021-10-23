namespace history_game
{
    public interface ICategory : IElementDependant
    {
        ///<returns>true if categories are equal or input is a category from which this derives</returns>
        bool IsA(ICategory c);
    }
}

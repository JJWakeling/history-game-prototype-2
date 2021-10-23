namespace ElegantCSharp
{
    ///<summary>
    /// object that can be initialised after creation
    ///</summary>
    public interface ILatch<T>
    {
        bool Latched();
        void Set(T value);
        T Value();
    }
}

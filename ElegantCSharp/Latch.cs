using System;
using System.Collections.Generic;
using System.Linq;

namespace ElegantCSharp
{
    public class Latch<T> : ILatch<T>
    {
        private readonly ICollection<T> _value;

        public Latch()
        {
            _value = new List<T>();
        }

        public bool Latched()
        {
            return _value.Any();
        }

        public void Set(T value)
        {
            if (Latched())
            {
                throw new Exception("Cannot set latch which is already set");
            }

            _value.Add(value);
        }

        public T Value()
        {
            if (Latched())
            {
                return _value.First();
            }

            throw new Exception("Cannot retrieve value from latch which is unset");
        }
    }
}

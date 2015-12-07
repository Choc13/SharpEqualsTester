using System;

namespace SharpEqualsTester.Exceptions
{
    internal class EqualToNullException<T> : Exception
    {
        public EqualToNullException(EqualityItem<T> obj)
            : base($"{obj} has equality with null")
        {
            
        }
    }
}
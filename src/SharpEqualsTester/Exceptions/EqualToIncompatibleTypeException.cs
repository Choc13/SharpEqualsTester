using System;

namespace SharpEqualsTester.Exceptions
{
    internal class EqualToIncompatibleTypeException<T> : Exception
    {
        public EqualToIncompatibleTypeException(EqualityItem<T> obj)
            : base($"{obj} compared equal to an incompatible type")
        {
            
        }
    }
}
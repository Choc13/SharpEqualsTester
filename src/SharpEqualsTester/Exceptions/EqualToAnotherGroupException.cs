using System;

namespace SharpEqualsTester.Exceptions
{
    internal class EqualToAnotherGroupException<T> : Exception
    {
        public EqualToAnotherGroupException(EqualityItem<T> obj, EqualityItem<T> other)
            : base($"{obj} compared equal to {other}")
        {
            
        }
    }
}
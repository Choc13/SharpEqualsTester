using System;

namespace SharpEqualsTester.Exceptions
{
    internal class HashcodeNotEqualToSameGroupException<T> : Exception
    {
        public HashcodeNotEqualToSameGroupException(EqualityItem<T> obj, EqualityItem<T> other)
            : base($"{obj} has a different hashcode to {other}")
        {
            
        }
    }
}
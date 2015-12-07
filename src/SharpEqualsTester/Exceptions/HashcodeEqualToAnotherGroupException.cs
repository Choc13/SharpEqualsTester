using System;

namespace SharpEqualsTester.Exceptions
{
    internal class HashcodeEqualToAnotherGroupException<T> : Exception
    {
        public HashcodeEqualToAnotherGroupException(EqualityItem<T> obj, EqualityItem<T> other)
            : base($"{obj} has the same hashcode as {other}")
        {
            
        }
    }
}
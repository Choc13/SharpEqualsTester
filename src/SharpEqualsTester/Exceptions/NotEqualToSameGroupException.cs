using System;

namespace SharpEqualsTester.Exceptions
{
    internal class NotEqualToSameGroupException<T> : Exception
    {
        public NotEqualToSameGroupException(EqualityItem<T> obj, EqualityItem<T> other)
            : base($"{obj} is not equal to {other}")
        {
        }
    }
}
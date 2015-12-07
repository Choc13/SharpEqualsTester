using SharpEqualsTester.Exceptions;
using System;
using System.Collections.Generic;

namespace SharpEqualsTester
{
    internal class EqualityItem<T>
    {
        public EqualityItem(T value, int index, int groupIndex)
        {
            Value = value;
            Index = index;
            GroupIndex = groupIndex;
        }
        
        public T Value { get; private set; }
        
        public int Index { get; private set; }
        
        public int GroupIndex { get; private set; }
        
        public void AssertNotEqualToNull()
        {
            if (Value.Equals(null))
            {
                throw new EqualToNullException<T>(this);
            }
        }
        
        public void AssertNotEqualToIncompatibleType()
        {
            if (Value.Equals(new IncompatibileType()))
            {
                throw new EqualToIncompatibleTypeException<T>(this);
            }
        }
        
        public void AssertEqualToSameGroup(List<EqualityItem<T>> items)
        {
            foreach (EqualityItem<T> item in items) 
            {
                if (GroupIndex != item.GroupIndex)
                {
                    throw new Exception($"Called AssertEqualToSameGroup on {this} with {item} which is from another equality group.");    
                }
                
                if (!Value.Equals(item.Value))
                {
                    throw new NotEqualToSameGroupException<T>(this, item);
                }
            }
        }
        
        public void AssertNotEqualToAnotherGroup(List<EqualityItem<T>> items)
        {
            foreach (EqualityItem<T> item in items)
            {
                if (GroupIndex == item.GroupIndex)
                {
                    throw new Exception($"Called AssertNotEqualToAnotherGroup on {this} with {item} which is from the same equality group");
                }
                
                if (Value.Equals(item.Value))
                {
                    throw new EqualToAnotherGroupException<T>(this, item);
                }
            }
        }
        
        public void AssertHashcodeEqualToSameGroup(List<EqualityItem<T>> items)
        {
            foreach (EqualityItem<T> item in items) 
            {
                if (GroupIndex != item.GroupIndex)
                {
                    throw new Exception($"Called AssertHashcodeEqualToSameGroup on {this} with {item} which is from another equality group.");    
                }
                
                if (!Value.GetHashCode().Equals(item.Value.GetHashCode()))
                {
                    throw new HashcodeNotEqualToSameGroupException<T>(this, item);
                }
            }
        }
        
        public void AssertHashCodeNotEqualToAnotherGroup(List<EqualityItem<T>> items)
        {
            foreach (EqualityItem<T> item in items)
            {
                if (GroupIndex == item.GroupIndex)
                {
                    throw new Exception($"Called AssertNotEqualToAnotherGroup on {this} with {item} which is from the same equality group");
                }
                
                if (Value.GetHashCode().Equals(item.Value.GetHashCode()))
                {
                    throw new HashcodeEqualToAnotherGroupException<T>(this, item);
                }
            }
        }
        
        public override string ToString()
        {
            return $"Item {Index} in group {GroupIndex}";
        }
        
        private class IncompatibileType
        {
            
        }
    }
}
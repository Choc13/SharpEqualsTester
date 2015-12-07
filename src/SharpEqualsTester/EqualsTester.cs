using System.Collections.Generic;
using System.Linq;

namespace SharpEqualsTester
{
    public class EqualsTester<T>
    {
        public EqualsTester()
        {
            m_equalityGroups = new List<List<EqualityItem<T>>>();
        }
        
        public EqualsTester<T> AddEqualityGroup(params T[] items)
        {
            int groupIndex = m_equalityGroups.Count;
            List<EqualityItem<T>> group = 
                items.Select(
                    (value, index) => new EqualityItem<T>(value, index, groupIndex)).ToList();
            m_equalityGroups.Add(group);
            return this;
        }
        
        public void Test()
        {
            foreach (var group in m_equalityGroups)
            {
                foreach (var item in group)
                {
                    item.AssertNotEqualToNull();
                    item.AssertNotEqualToIncompatibleType();
                    item.AssertEqualToSameGroup(group);
                    item.AssertHashcodeEqualToSameGroup(group);
                    foreach (var otherGroup in m_equalityGroups.Where((_, index) => index != item.GroupIndex))
                    {
                        item.AssertNotEqualToAnotherGroup(otherGroup);
                        item.AssertHashCodeNotEqualToAnotherGroup(otherGroup);
                    }
                }   
            }
        }
        
        private readonly List<List<EqualityItem<T>>> m_equalityGroups;
    }
}

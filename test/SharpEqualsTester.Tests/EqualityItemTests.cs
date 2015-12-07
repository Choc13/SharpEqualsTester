using SharpEqualsTester.Exceptions;
using SharpEqualsTester.Tests.TestObjects;
using System;
using System.Linq;
using Xunit;

namespace SharpEqualsTester.Tests
{
    public class EqualityItemTests
    {   
        [Fact]
        public void ShouldAssertNotEqualToNull()
        {
            var obj = new EqualToNullClass("test");
            var item = new EqualityItem<EqualToNullClass>(obj, 0, 0);
            Assert.Throws<EqualToNullException<EqualToNullClass>>(() => item.AssertNotEqualToNull());
        }
        
        [Fact]
        public void ShouldAssertNotEqualToIncompatibleType()
        {
            var obj = new EqualToIncompatibleTypeClass("test");
            var item = new EqualityItem<EqualToIncompatibleTypeClass>(obj, 0, 0);
            Assert.Throws<EqualToIncompatibleTypeException<EqualToIncompatibleTypeClass>>(() => item.AssertNotEqualToIncompatibleType());
        }
        
        [Fact]
        public void ShouldAssertEqualToSameGroup()
        {
            var obj1A = new InconsistentEqualsClass("test", 1);
            var obj1B = new InconsistentEqualsClass("test", 1);
            var item1A = new EqualityItem<InconsistentEqualsClass>(obj1A, 0, 0);
            var item1B = new EqualityItem<InconsistentEqualsClass>(obj1B, 1, 0);
            var group1 = new [] {item1A, item1B};
            Assert.Throws<NotEqualToSameGroupException<InconsistentEqualsClass>>(() => item1A.AssertEqualToSameGroup(group1.ToList()));
        }
        
        [Fact]
        public void ShouldThrowWhenAssertEqualToSameGroupWithAnotherGroup()
        {
            var obj1A = new PerfectClass("test", 1);
            var obj2A = new PerfectClass("other", 1);
            var item1A = new EqualityItem<PerfectClass>(obj1A, 0, 0);
            var item2A = new EqualityItem<PerfectClass>(obj2A, 0, 1);
            var group2 = new [] {item2A};
            Assert.Throws<Exception>(() => item1A.AssertEqualToSameGroup(group2.ToList()));
        }
        
        [Fact]
        public void ShouldAssertNotEqualToAnotherGroup()
        {
            var obj1A = new EqualsNotUsingAllMembersClass("test", 1);
            var obj2A = new EqualsNotUsingAllMembersClass("test", 2);
            var item1A = new EqualityItem<EqualsNotUsingAllMembersClass>(obj1A, 0, 0);
            var item2A = new EqualityItem<EqualsNotUsingAllMembersClass>(obj2A, 0, 1);
            var group2 = new [] {item2A};
            Assert.Throws<EqualToAnotherGroupException<EqualsNotUsingAllMembersClass>>(() => item1A.AssertNotEqualToAnotherGroup(group2.ToList()));
        }
        
        [Fact]
        public void ShouldThrowWhenAssertEqualToAnotherGroupWithSameGroup()
        {
            var obj1A = new PerfectClass("test", 1);
            var item1A = new EqualityItem<PerfectClass>(obj1A, 0, 0);
            var group1 = new [] {item1A};
            Assert.Throws<Exception>(() => item1A.AssertNotEqualToAnotherGroup(group1.ToList()));
        }
        
        [Fact]
        public void ShouldAssertHashcodeEqualToSameGroup()
        {
            var obj1A = new InconsistentHashcodeClass("test", 1);
            var obj1B = new InconsistentHashcodeClass("test", 1);
            var item1A = new EqualityItem<InconsistentHashcodeClass>(obj1A, 0, 0);
            var item1B = new EqualityItem<InconsistentHashcodeClass>(obj1B, 1, 0);
            var group1 = new [] {item1A, item1B};
            Assert.Throws<HashcodeNotEqualToSameGroupException<InconsistentHashcodeClass>>(() => item1A.AssertHashcodeEqualToSameGroup(group1.ToList()));
        }
        
        [Fact]
        public void ShouldThrowWhenAssertHashcodeEqualToSameGroupWithAnotherGroup()
        {
            var obj1A = new PerfectClass("test", 1);
            var obj2A = new PerfectClass("other", 1);
            var item1A = new EqualityItem<PerfectClass>(obj1A, 0, 0);
            var item2A = new EqualityItem<PerfectClass>(obj2A, 0, 1);
            var group2 = new [] {item2A};
            Assert.Throws<Exception>(() => item1A.AssertHashcodeEqualToSameGroup(group2.ToList()));
        }
        
        [Fact]
        public void ShouldAssertHashCodeNotEqualToAnotherGroup()
        {
            var obj1A = new HashcodeNotUsingAllMembersClass("test", 1);
            var obj2A = new HashcodeNotUsingAllMembersClass("test", 2);
            var item1A = new EqualityItem<HashcodeNotUsingAllMembersClass>(obj1A, 0, 0);
            var item2A = new EqualityItem<HashcodeNotUsingAllMembersClass>(obj2A, 0, 1);
            var group2 = new [] {item2A};
            Assert.Throws<HashcodeEqualToAnotherGroupException<HashcodeNotUsingAllMembersClass>>(() => item1A.AssertHashCodeNotEqualToAnotherGroup(group2.ToList()));
        }
        
        [Fact]
        public void ShouldThrowWhenAssertHashcodeNotEqualToAnotherGroupWithSameSameGroup()
        {
            var obj1A = new PerfectClass("test", 1);
            var item1A = new EqualityItem<PerfectClass>(obj1A, 0, 0);
            var group1 = new [] {item1A};
            Assert.Throws<Exception>(() => item1A.AssertHashCodeNotEqualToAnotherGroup(group1.ToList()));
        }
        
        [Fact]
        public void ShouldImplementToString()
        {
            var index = 1;
            var groupIndex = 2;
            var item = new EqualityItem<string>("test", index, groupIndex);
            var expectedString = $"Item {index} in group {groupIndex}";
            Assert.Equal(item.ToString(), expectedString);
        }
    }
}
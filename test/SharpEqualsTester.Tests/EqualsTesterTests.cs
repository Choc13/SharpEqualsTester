using SharpEqualsTester.Exceptions;
using SharpEqualsTester.Tests.TestObjects;
using Xunit;

namespace SharpEqualsTester.Tests
{
    public class EqualsTesterTests
    {   
        [Fact]
        public void ShouldPassIfEqualsAndHashcodePerfectlyImplemented()
        {
            var object00 = new PerfectClass("test", 1);
            var object10 = new PerfectClass("other", 1);
            var object11 = new PerfectClass("other", 1);
            var object20 = new PerfectClass("test", 2);
            var object21 = new PerfectClass("test", 2);
            new EqualsTester<PerfectClass>()
                .AddEqualityGroup(object00)
                .AddEqualityGroup(object10, object11)
                .AddEqualityGroup(object20, object21)
                .Test();
        }
        
        [Fact]
        public void ShouldFailIfAnyItemInGroupIsNotEqualToOthers() 
        {
            var object1A = new InconsistentEqualsClass("test", 1);
            var object1B = new InconsistentEqualsClass("test", 1);
            var equalityTester = new EqualsTester<InconsistentEqualsClass>();
            equalityTester.AddEqualityGroup(object1A, object1B);
            Assert.Throws<NotEqualToSameGroupException<InconsistentEqualsClass>>(() => equalityTester.Test());
        }
        
        [Fact]
        public void ShouldFailIfItemsInDifferentGroupsAreEqual() 
        {
            var object1A = new EqualsNotUsingAllMembersClass("test", 1);
            var object2A = new EqualsNotUsingAllMembersClass("test", 2);
            var object2B = new EqualsNotUsingAllMembersClass("test", 2);
            var equalityTester = new EqualsTester<EqualsNotUsingAllMembersClass>();
            equalityTester
                .AddEqualityGroup(object1A)
                .AddEqualityGroup(object2A, object2B);
            Assert.Throws<EqualToAnotherGroupException<EqualsNotUsingAllMembersClass>>(() => equalityTester.Test());
        }
        
        [Fact]
        public void ShouldFailIfAnyItemIsEqualToNull()
        {
            var object1A = new EqualToNullClass("test");
            var equalityTester = new EqualsTester<EqualToNullClass>();
            equalityTester.AddEqualityGroup(object1A);
            Assert.Throws<EqualToNullException<EqualToNullClass>>(() => equalityTester.Test());
        }
        
        [Fact]
        public void ShouldFailIfAnyItemIsEqualToIncompatibleType()
        {
            var object1A = new EqualToIncompatibleTypeClass("test");
            var equalityTester = new EqualsTester<EqualToIncompatibleTypeClass>();
            equalityTester.AddEqualityGroup(object1A);
            Assert.Throws<EqualToIncompatibleTypeException<EqualToIncompatibleTypeClass>>(() => equalityTester.Test());
        }
        
        [Fact]
        public void ShouldFailIfAnyItemsInGroupHaveDifferentHashcodes()
        {
            var object1A = new InconsistentHashcodeClass("test", 1);
            var object1B = new InconsistentHashcodeClass("test", 1);
            var object2A = new InconsistentHashcodeClass("test", 2);
            var object2B = new InconsistentHashcodeClass("test", 2);
            var equalityTester = new EqualsTester<InconsistentHashcodeClass>();
            equalityTester.AddEqualityGroup(object1A, object1B);
            equalityTester.AddEqualityGroup(object2A, object2B);
            Assert.Throws<HashcodeNotEqualToSameGroupException<InconsistentHashcodeClass>>(() => equalityTester.Test());
        }
        
        [Fact]
        public void ShouldFailIfItemsInDifferentGroupsHaveSameHashcode() 
        {
            var object1A = new HashcodeNotUsingAllMembersClass("test", 1);
            var object1B = new HashcodeNotUsingAllMembersClass("test", 1);
            var object2A = new HashcodeNotUsingAllMembersClass("test", 2);
            var object2B = new HashcodeNotUsingAllMembersClass("test", 2);
            var equalityTester = new EqualsTester<HashcodeNotUsingAllMembersClass>();
            equalityTester.AddEqualityGroup(object1A, object1B);
            equalityTester.AddEqualityGroup(object2A, object2B);
            Assert.Throws<HashcodeEqualToAnotherGroupException<HashcodeNotUsingAllMembersClass>>(() => equalityTester.Test());
        } 
        
        [Fact(Skip="Not sure I want to implement this")]
        public void ShouldThrowIfGroupContainsSameInstanceMoreThanOnce()
        {
            // It is probably a mistake on the part of the tester if the same instance is included in a 
            // group multiple times as this is a useless test
        }
    }
}

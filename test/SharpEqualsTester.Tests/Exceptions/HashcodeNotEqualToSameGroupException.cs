using SharpEqualsTester.Exceptions;
using Xunit;

namespace SharpEqualsTester.Tests.Exceptions
{
    public class HashcodeNotEqualToSameGroupExceptionTests
    {   
        [Fact]
        public void ShouldHaveCorrectMessage()
        {
            var obj = new EqualityItem<string>("test", 0, 0);
            var other = new EqualityItem<string>("test", 1, 0);
            var exception = new HashcodeNotEqualToSameGroupException<string>(obj, other);
            var expectedMessage = $"{obj} has a different hashcode to {other}";
            Assert.Equal(exception.Message, expectedMessage); 
        }
    }
}

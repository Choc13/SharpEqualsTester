using SharpEqualsTester.Exceptions;
using Xunit;

namespace SharpEqualsTester.Tests.Exceptions
{
    public class HashcodeEqualToAnotherGroupExceptionTests
    {   
        [Fact]
        public void ShouldHaveCorrectMessage()
        {
            var obj = new EqualityItem<string>("test", 0, 0);
            var other = new EqualityItem<string>("test", 1, 0);
            var exception = new HashcodeEqualToAnotherGroupException<string>(obj, other);
            var expectedMessage = $"{obj} has the same hashcode as {other}";
            Assert.Equal(exception.Message, expectedMessage); 
        }
    }
}

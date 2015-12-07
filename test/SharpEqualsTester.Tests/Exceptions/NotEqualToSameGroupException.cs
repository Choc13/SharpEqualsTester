using SharpEqualsTester.Exceptions;
using Xunit;

namespace SharpEqualsTester.Tests.Exceptions
{
    public class NotEqualToSameGroupExceptionTests
    {   
        [Fact]
        public void ShouldHaveCorrectMessage()
        {
            var obj = new EqualityItem<string>("test", 0, 0);
            var other = new EqualityItem<string>("test", 1, 0);
            var exception = new NotEqualToSameGroupException<string>(obj, other);
            var expectedMessage = $"{obj} is not equal to {other}";
            Assert.Equal(exception.Message, expectedMessage); 
        }
    }
}

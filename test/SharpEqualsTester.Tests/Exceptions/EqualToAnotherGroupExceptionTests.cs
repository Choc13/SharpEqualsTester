using SharpEqualsTester.Exceptions;
using Xunit;

namespace SharpEqualsTester.Tests.Exceptions
{
    public class EqualToAnotherGroupExceptionTests
    {   
        [Fact]
        public void ShouldHaveCorrectMessage()
        {
            var obj = new EqualityItem<string>("test", 0, 0);
            var other = new EqualityItem<string>("test", 1, 0);
            var exception = new EqualToAnotherGroupException<string>(obj, other);
            var expectedMessage = $"{obj} compared equal to {other}";
            Assert.Equal(exception.Message, expectedMessage); 
        }
    }
}

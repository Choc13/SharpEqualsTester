using SharpEqualsTester.Exceptions;
using Xunit;

namespace SharpEqualsTester.Tests.Exceptions
{
    public class EqualToNullExceptionTests
    {   
        [Fact]
        public void ShouldHaveCorrectMessage()
        {
            var obj = new EqualityItem<string>("test", 0, 0);
            var exception = new EqualToNullException<string>(obj);
            var expectedMessage = $"{obj} has equality with null";
            Assert.Equal(exception.Message, expectedMessage); 
        }
    }
}

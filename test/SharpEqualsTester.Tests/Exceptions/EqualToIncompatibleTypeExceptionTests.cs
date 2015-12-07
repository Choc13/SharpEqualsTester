using SharpEqualsTester.Exceptions;
using Xunit;

namespace SharpEqualsTester.Tests.Exceptions
{
    public class EqualToIncompatibleTypeExceptionTests
    {   
        [Fact]
        public void ShouldHaveCorrectMessage()
        {
            var obj = new EqualityItem<string>("test", 0, 0);
            var exception = new EqualToIncompatibleTypeException<string>(obj);
            var expectedMessage = $"{obj} compared equal to an incompatible type";
            Assert.Equal(exception.Message, expectedMessage); 
        }
    }
}

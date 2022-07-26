using GodelTech.Microservices.Business.Tests.Fakes;
using Xunit;

namespace GodelTech.Microservices.Business.Tests
{
    public class BusinessInitializerTests
    {
        [Fact]
        public void Constructor_Success()
        {
            // Arrange & Act
            var initializer = new BusinessInitializer<FakeStartup>();

            // Assert
            Assert.NotNull(initializer);
        }
    }
}

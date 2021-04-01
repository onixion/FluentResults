using Xunit;

namespace AlinSpace.FluentResults.Tests
{
    /// <summary>
    /// Tests for <see cref="Optional{TReturn}"/>.
    /// </summary>
    public partial class Optional
    {
        [Fact]
        public void Result_Equals_1()
        {
            // Setup
            var result = Optional<int>.Return(5);
            int number = 5;

            // Assert
            Assert.True(result.Equals(number));
        }

        [Fact]
        public void Result_Equals_2()
        {
            // Setup
            var result = Optional<int>.None();
            int number = 5;

            // Assert
            Assert.False(result.Equals(number));
        }

        [Fact]
        public void Result_Equals_3()
        {
            // Setup
            var resultA = Optional<int>.Return(2);
            var resultB = Optional<int>.None();

            // Assert
            Assert.False(resultA.Equals(resultB));
        }

        [Fact]
        public void Result_Equals_4()
        {
            // Setup
            var resultA = Optional<int>.None();
            var resultB = Optional<int>.Return(2);

            // Assert
            Assert.False(resultA.Equals(resultB));
        }

        [Fact]
        public void Result_Equals_5()
        {
            // Setup
            var resultA = Optional<int>.Return(2);
            var resultB = Optional<int>.Return(2);

            // Assert
            Assert.True(resultA.Equals(resultB));
        }

        [Fact]
        public void Result_Equals_6()
        {
            // Setup
            var resultA = Optional<int>.None();
            var resultB = Optional<int>.None();

            // Assert
            Assert.True(resultA.Equals(resultB));
        }
    }
}

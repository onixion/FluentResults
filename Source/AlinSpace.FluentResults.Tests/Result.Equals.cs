using Xunit;

namespace AlinSpace.FluentResults.Tests
{
    public partial class Result
    {
        [Fact]
        public void Result_Equals_1()
        {
            // Setup
            var result = Result<int>.Return(5);
            int number = 5;

            // Assert
            Assert.True(result.Equals(number));
        }

        [Fact]
        public void Result_Equals_2()
        {
            // Setup
            var result = Result<int>.None();
            int number = 5;

            // Assert
            Assert.False(result.Equals(number));
        }

        [Fact]
        public void Result_Equals_3()
        {
            // Setup
            var resultA = Result<int>.Return(2);
            var resultB = Result<int>.None();

            // Assert
            Assert.False(resultA.Equals(resultB));
        }

        [Fact]
        public void Result_Equals_4()
        {
            // Setup
            var resultA = Result<int>.None();
            var resultB = Result<int>.Return(2);

            // Assert
            Assert.False(resultA.Equals(resultB));
        }

        [Fact]
        public void Result_Equals_5()
        {
            // Setup
            var resultA = Result<int>.Return(2);
            var resultB = Result<int>.Return(2);

            // Assert
            Assert.True(resultA.Equals(resultB));
        }

        [Fact]
        public void Result_Equals_6()
        {
            // Setup
            var resultA = Result<int>.None();
            var resultB = Result<int>.None();

            // Assert
            Assert.True(resultA.Equals(resultB));
        }

        [Fact]
        public void ResultError_Equals_1()
        {
            // Setup
            var result = Result<int, string>.Return(5);
            int number = 5;

            // Assert
            Assert.True(result.Equals(number));
        }

        [Fact]
        public void ResultError_Equals_2()
        {
            // Setup
            var result = Result<int, string>.Error("Test");
            int number = 5;

            // Assert
            Assert.False(result.Equals(number));
        }

        [Fact]
        public void ResultError_Equals_3()
        {
            // Setup
            var resultA = Result<int, string>.Return(2);
            var resultB = Result<int, string>.Error("Test");

            // Assert
            Assert.False(resultA.Equals(resultB));
        }

        [Fact]
        public void ResultError_Equals_4()
        {
            // Setup
            var resultA = Result<int, string>.Error("Test");
            var resultB = Result<int, string>.Return(2);

            // Assert
            Assert.False(resultA.Equals(resultB));
        }

        [Fact]
        public void ResultError_Equals_5()
        {
            // Setup
            var resultA = Result<int, string>.Return(2);
            var resultB = Result<int, string>.Return(2);

            // Assert
            Assert.True(resultA.Equals(resultB));
        }

        [Fact]
        public void ResultError_Equals_6()
        {
            // Setup
            var resultA = Result<int, string>.Error("Test");
            var resultB = Result<int, string>.Error("Test");

            // Assert
            Assert.True(resultA.Equals(resultB));
        }
    }
}

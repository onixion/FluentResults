using System;
using Xunit;
using FluentAssertions;

namespace AlinSpace.FluentReturns
{
    public class Result
    {
        [Fact]
        public void Result_1()
        {
            // Act
            var result = Result<int>.Return(5);

            // Assert
            result.HasValue.Should().BeTrue();
            result.Value.Should().Be(5);
        }

        [Fact]
        public void Result_2()
        {
            // Act
            var result = Result<int>.None();

            // Assert
            Assert.Throws<Exception>(() => result.Value);
            result.HasValue.Should().BeFalse();
        }

        [Fact]
        public void ResultError_1()
        {
            // Act
            var result = Result<int, string>.Return(5);

            // Assert
            result.HasValue.Should().BeTrue();
            result.Value.Should().Be(5);
        }

        [Fact]
        public void ResultError_2()
        {
            // Act
            var result = Result<string, string>.Error("Test");

            // Assert
            result.HasValue.Should().BeFalse();
            Assert.Throws<Exception>(() => result.Value);
            result.ValueOrDefault.Should().BeNull();
            result.ErrorValue.Should().Be("Test");
        }
    }
}

using FluentAssertions;
using System;
using Xunit;

namespace AlinSpace.FluentResults.Tests
{
    /// <summary>
    /// Tests for <see cref="Result{TReturn, TError}"/>.
    /// </summary>
    public partial class Result
    {
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

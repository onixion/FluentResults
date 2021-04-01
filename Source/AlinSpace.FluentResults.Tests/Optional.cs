using FluentAssertions;
using System;
using Xunit;

namespace AlinSpace.FluentResults.Tests
{
    /// <summary>
    /// Tests for <see cref="Optional{TReturn}"/>.
    /// </summary>
    public partial class Optional
    {
        [Fact]
        public void Result_1()
        {
            // Act
            var result = Optional<int>.Return(5);

            // Assert
            result.HasValue.Should().BeTrue();
            result.Value.Should().Be(5);
        }

        [Fact]
        public void Result_2()
        {
            // Act
            var result = Optional<int>.None();

            // Assert
            Assert.Throws<Exception>(() => result.Value);
            result.HasValue.Should().BeFalse();
        }

    }
}

using Xunit;

namespace AlinSpace.FluentResults.Tests
{
    /// <summary>
    /// Tests for <see cref="Result{TReturn, TError}"/>.
    /// </summary>
    public partial class Result
    {
        [Fact]
        public void Result_Match_1()
        {
            // Setup
            var result = Optional<int>.Return(5);

            // WIP
        }
    }
}

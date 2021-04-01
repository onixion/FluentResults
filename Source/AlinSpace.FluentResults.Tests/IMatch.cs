namespace AlinSpace.FluentResults.Tests
{
    /// <summary>
    /// This interface is used for testing.
    /// </summary>
    /// <typeparam name="TReturn">Type of return value.</typeparam>
    /// <typeparam name="TError">Type of error value.</typeparam>
    public interface IMatch<TReturn, TError>
    {
        void Return(TReturn returnValue);

        void Error(TError errorValue);
    }
}

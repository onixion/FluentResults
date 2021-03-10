namespace AlinSpace.FluentResults.Tests
{
    public interface IMatch<TReturn, TError>
    {
        void Return(TReturn returnValue);

        void Error(TError errorValue);
    }
}

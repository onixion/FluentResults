namespace AlinSpace.FluentResults
{
    /// <summary>
    /// Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Construct result from return value.
        /// </summary>
        /// <typeparam name="TReturn">Type of return value.</typeparam>
        /// <param name="returnValue">Return value.</param>
        /// <returns>Result.</returns>
        public static Result<TReturn> ToResult<TReturn>(this TReturn returnValue)
        {
            return Result<TReturn>.Return(returnValue);
        }

        /// <summary>
        /// Construct result from return value.
        /// </summary>
        /// <typeparam name="TReturn">Type of return value.</typeparam>
        /// <typeparam name="TError">Type of error value.</typeparam>
        /// <param name="returnValue">Return value.</param>
        /// <returns>Result.</returns>
        public static Result<TReturn, TError> ToResult<TReturn, TError>(this TReturn returnValue)
        {
            return Result<TReturn, TError>.Return(returnValue);
        }

        /// <summary>
        /// Construct result from error value.
        /// </summary>
        /// <typeparam name="TReturn">Type of return value.</typeparam>
        /// <typeparam name="TError">Type of error value.</typeparam>
        /// <param name="errorValue">Error value.</param>
        /// <returns>Result.</returns>
        public static Result<TReturn, TError> ToResult<TReturn, TError>(this TError errorValue)
        {
            return Result<TReturn, TError>.Error(errorValue);
        }
    }
}

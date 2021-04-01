using System;

namespace AlinSpace.FluentResults
{
    /// <summary>
    /// Extensions for <see cref="Optional{TReturn}"/> and <see cref="Result{TReturn, TError}"/>.
    /// </summary>
    public static class ResultExtensions
    {
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

        /// <summary>
        /// Match result.
        /// </summary>
        /// <typeparam name="TReturn">Type of return value.</typeparam>
        /// <typeparam name="TError">Type of error value.</typeparam>
        /// <param name="result">Result.</param>
        /// <param name="returnFunction">Return function called when result has a value.</param>
        /// <param name="errorFunction">Error function called when result has an error.</param>
        /// <returns>Result.</returns>
        public static Result<TReturn, TError> Match<TReturn, TError>(
            this Result<TReturn, TError> result,
            Action<TReturn> returnFunction = null,
            Action<TError> errorFunction = null)
        {
            if (result.HasValue)
            {
                returnFunction?.Invoke(result.Value);
            }
            else
            {
                errorFunction?.Invoke(result.ErrorValue);
            }

            return result;
        }

        /// <summary>
        /// Match result.
        /// </summary>
        /// <typeparam name="TReturn">Type of return value.</typeparam>
        /// <typeparam name="TError">Type of error value.</typeparam>
        /// <param name="result">Result.</param>
        /// <param name="returnFunction">Return function called when result has a value.</param>
        /// <param name="errorFunction">Error function called when result has an error.</param>
        /// <returns>Result.</returns>
        public static Result<TReturn, TError> MatchOrDefault<TReturn, TError>(
            this Result<TReturn, TError> result,
            Action<TReturn> returnFunction = null,
            Action<TError> errorFunction = null)
        {
            if (result.HasValue)
            {
                returnFunction?.Invoke(result.ValueOrDefault);
            }
            else
            {
                errorFunction?.Invoke(result.ErrorValueOrDefault);
            }

            return result;
        }
    }
}

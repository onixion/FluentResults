using System;

namespace AlinSpace.FluentResults
{
    /// <summary>
    /// Extensions for <see cref="Optional{TReturn}"/>.
    /// </summary>
    public static class OptionalExtensions
    {
        /// <summary>
        /// Construct result from return value.
        /// </summary>
        /// <typeparam name="TReturn">Type of return value.</typeparam>
        /// <param name="returnValue">Return value.</param>
        /// <returns>Result.</returns>
        public static Optional<TReturn> ToResult<TReturn>(this TReturn returnValue)
        {
            return Optional<TReturn>.Return(returnValue);
        }

        /// <summary>
        /// Match optional.
        /// </summary>
        /// <typeparam name="TReturn">Type of return value.</typeparam>
        /// <param name="optional">Optional.</param>
        /// <param name="returnFunction">Return function called when result has a value.</param>
        /// <param name="emptyFunction">Empty function called when the optional is empty.</param>
        /// <returns>Optional.</returns>
        public static Optional<TReturn> Match<TReturn>(
            this Optional<TReturn> optional,
            Action<TReturn> returnFunction = null,
            Action emptyFunction = null)
        {
            if (optional.HasValue)
            {
                returnFunction?.Invoke(optional.Value);
            }
            else
            {
                emptyFunction?.Invoke();
            }

            return optional;
        }
    }
}

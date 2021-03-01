using System;
using System.Diagnostics;

namespace AlinSpace.FluentResults
{
    /// <summary>
    /// Result.
    /// </summary>
    /// <typeparam name="TReturn">Type of return value.</typeparam>
    [DebuggerDisplay("HasValue={HasValue} ValueOrDefault={ValueOrDefault}")]
    public class Result<TReturn>
    {
        /// <summary>
        /// Value.
        /// </summary>
        public TReturn Value
        {
            get
            {
                if (!HasValue)
                    throw new Exception();

                return ValueOrDefault;
            }
        }

        /// <summary>
        /// Value or default.
        /// </summary>
        public TReturn ValueOrDefault { get; private set; } = default;

        /// <summary>
        /// Has value.
        /// </summary>
        public bool HasValue { get; private set; }

        /// <summary>
        /// Return value.
        /// </summary>
        /// <param name="returnValue">Value to return.</param>
        /// <returns>Result with return value.</returns>
        public static Result<TReturn> Return(TReturn returnValue)
        {
            return new Result<TReturn>
            {
                ValueOrDefault = returnValue,
                HasValue = true,
            };
        }

        /// <summary>
        /// Return none.
        /// </summary>
        /// <returns>Result with no value.</returns>
        public static Result<TReturn> None()
        {
            return new Result<TReturn>
            {
                HasValue = false,
            };
        }

        /// <summary>
        /// Get value or default value.
        /// </summary>
        /// <param name="defaultValue">Optional default value.</param>
        /// <returns>Value or default value.</returns>
        public TReturn ValueOr(TReturn defaultValue = default)
        {
            return HasValue ? Value : defaultValue;
        }

        /// <summary>
        /// Implicit cast to type <typeparamref name="TReturn"/>.
        /// </summary>
        /// <param name="result">Result to cast.</param>
        public static implicit operator TReturn(Result<TReturn> result)
        {
            return result.Value;
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        public override int GetHashCode()
        {
            if (HasValue)
            {
                return ValueOrDefault.GetHashCode();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Equals.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (HasValue)
            {
                if (obj is TReturn returnValue)
                {
                    return Value.Equals(returnValue);
                }

                if (obj is Result<TReturn> result)
                {
                    if (result.HasValue)
                    {
                        return Value.Equals(result.Value);
                    }
                }
            }
            else
            {
                if (obj is Result<TReturn> result)
                {
                    if (!result.HasValue)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// To string.
        /// </summary>
        public override string ToString()
        {
            if (HasValue)
            {
                return ValueOrDefault.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// Result.
    /// </summary>
    /// <typeparam name="TReturn">Type of the return value.</typeparam>
    /// <typeparam name="TError">Type of the error value.</typeparam>
    [DebuggerDisplay("HasValue={HasValue} Value={ValueOrDefault} Error={ErrorValueOrDefault}")]
    public class Result<TReturn, TError>
    {
        /// <summary>
        /// Value.
        /// </summary>
        public TReturn Value 
        { 
            get
            {
                if (!HasValue)
                    throw new Exception();

                return ValueOrDefault;
            }
        }

        /// <summary>
        /// Value or default.
        /// </summary>
        public TReturn ValueOrDefault { get; private set; } = default;

        /// <summary>
        /// Error value.
        /// </summary>
        public TError ErrorValue
        {
            get
            {
                if (HasValue)
                    throw new Exception();

                return ErrorValueOrDefault;
            }
        }
        
        /// <summary>
        /// Error value or default value.
        /// </summary>
        public TError ErrorValueOrDefault { get; private set; } = default;

        /// <summary>
        /// Has value.
        /// </summary>
        public bool HasValue { get; private set; }

        /// <summary>
        /// Return value.
        /// </summary>
        /// <param name="returnValue">Return value.</param>
        /// <returns>Result with return value.</returns>
        public static Result<TReturn, TError> Return(TReturn returnValue)
        {
            return new Result<TReturn, TError>
            {
                ValueOrDefault = returnValue,
                HasValue = true,
            };
        }

        /// <summary>
        /// Return error.
        /// </summary>
        /// <param name="errorValue">Error value.</param>
        /// <returns>Result with error value.</returns>
        public static Result<TReturn, TError> Error(TError errorValue)
        {
            return new Result<TReturn, TError>
            {
                ErrorValueOrDefault = errorValue,
                HasValue = false,
            };
        }

        /// <summary>
        /// Get value or default value.
        /// </summary>
        /// <param name="defaultValue">Optional default value.</param>
        /// <returns>Value or default value.</returns>
        public TReturn ValueOr(TReturn defaultValue = default)
        {
            return HasValue ? Value : defaultValue;
        }

        /// <summary>
        /// Get error or default value.
        /// </summary>
        /// <param name="defaultValue">Optional default value.</param>
        /// <returns>Error or default value.</returns>
        public TError ErrorOr(TError defaultValue = default)
        {
            return !HasValue ? ErrorValueOrDefault : defaultValue;
        }

        /// <summary>
        /// Implicit cast to type <typeparamref name="TReturn"/>.
        /// </summary>
        /// <param name="result">Result to cast.</param>
        public static implicit operator TReturn(Result<TReturn, TError> result)
        {
            return result.Value;
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        public override int GetHashCode()
        {
            if (HasValue)
            {
                return ValueOrDefault.GetHashCode();
            }
            else
            {
                return ErrorValueOrDefault.GetHashCode();
            }
        }

        /// <summary>
        /// Equals.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (HasValue)
            {
                if (obj is TReturn returnResult)
                {
                    return Value.Equals(returnResult);
                }

                if (obj is Result<TReturn, TError> result)
                {
                    if (result.HasValue)
                    {
                        return Value.Equals(result.Value);
                    }
                }
            }
            else
            {
                if (obj is Result<TReturn, TError> result)
                {
                    if (!result.HasValue)
                    {
                        return ErrorValue.Equals(result.ErrorValue);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// To string.
        /// </summary>
        public override string ToString()
        {
            if (HasValue)
            {
                return ValueOrDefault.ToString();
            }
            else
            {
                return ErrorValueOrDefault.ToString();
            }
        }
    }
}

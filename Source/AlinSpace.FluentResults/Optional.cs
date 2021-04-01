using System;
using System.Diagnostics;

namespace AlinSpace.FluentResults
{
    /// <summary>
    /// Optional.
    /// </summary>
    /// <typeparam name="TReturn">Type of return value.</typeparam>
    [DebuggerDisplay("HasValue={HasValue} ValueOrDefault={ValueOrDefault}")]
    public class Optional<TReturn>
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
        public static Optional<TReturn> Return(TReturn returnValue)
        {
            return new Optional<TReturn>
            {
                ValueOrDefault = returnValue,
                HasValue = true,
            };
        }

        /// <summary>
        /// Return none.
        /// </summary>
        /// <returns>Result with no value.</returns>
        public static Optional<TReturn> None()
        {
            return new Optional<TReturn>
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
        /// Implicit cast.
        /// </summary>
        /// <param name="result">Result to wrap.</param>
        public static implicit operator Optional<TReturn>(TReturn result)
        {
            return Return(result);
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

                if (obj is Optional<TReturn> result)
                {
                    if (result.HasValue)
                    {
                        return Value.Equals(result.Value);
                    }
                }
            }
            else
            {
                if (obj is Optional<TReturn> result)
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
}

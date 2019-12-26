namespace Rhythm.Core
{

    // Namespaces.
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;

    /// <summary>
    /// A collection of extension methods to support the <see cref="NameValueCollection"/> interface.
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        #region Properties
        /// <summary>
        /// Gets a boolean value or fallback.
        /// </summary>
        /// <param name="nvc">The name value collection.</param>
        /// <param name="key">The expected key.</param>
        /// <param name="fallback">The fallback value if no value is found.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        public static bool GetBooleanValue(this NameValueCollection nvc, string key, bool fallback = default(bool))
        {
            if (nvc.TryGetValue(key, out var initialValue) == false)
            {
                return fallback;
            }

            return bool.TryParse(initialValue, out var value) ? value : fallback;
        }

        /// <summary>
        /// Gets a single integer value or fallback.
        /// </summary>
        /// <param name="nvc">The name value collection.</param>
        /// <param name="key">The expected key.</param>
        /// <param name="fallback">The fallback value if no value is found.</param>
        /// <returns>A <see cref="int"/>.</returns>
        public static int GetIntegerValue(this NameValueCollection nvc, string key, int fallback = default(int))
        {
            if (nvc.TryGetValue(key, out var initialValue) == false)
            {
                return fallback;
            }

            return int.TryParse(initialValue, out var value) ? value : fallback;
        }

        /// <summary>
        /// Gets a single string value or fallback.
        /// </summary>
        /// <param name="nvc">The name value collection.</param>
        /// <param name="key">The expected key.</param>
        /// <param name="fallback">The fallback value if no value is found.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public static string GetStringValue(this NameValueCollection nvc, string key, string fallback = default(string))
        {
            return nvc.TryGetValue(key, out var value) ? value : fallback;
        }

        /// <summary>
        /// Checks if the name value collection contains a key.
        /// </summary>
        /// <param name="nvc">The name value collection.</param>
        /// <param name="key">The expecteed key.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        public static bool HasKey(this NameValueCollection nvc, string key)
        {
            return nvc.AllKeys.Contains(key);
        }

        /// <summary>
        /// Trys to get a single string value from a name value collection. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="nvc">The name value collection.</param>
        /// <param name="key">The expected key.</param>
        /// <param name="value">The output value.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        public static bool TryGetValue(this NameValueCollection nvc, string key, out string value)
        {
            value = default(string);

            if (nvc.TryGetValues(key, out var values) == false)
            {
                return false;
            }

            value = values.FirstOrDefault();

            return true;
        }

        /// <summary>
        /// Trys to get an array of sanitized string values from a name value collection. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="nvc">The name value collection.</param>
        /// <param name="key">The expected key.</param>
        /// <param name="values">The output values.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        public static bool TryGetValues(this NameValueCollection nvc, string key, out IEnumerable<string> values)
        {
            values = Enumerable.Empty<string>();

            if (nvc.HasKey(key) == false)
            {
                return false;
            }

            var nvcValues = nvc.GetValues(key)?.Where(v => string.IsNullOrWhiteSpace(v) == false).ToArray();

            if (nvcValues == null || nvcValues.Any() == false)
            {
                return false;
            }

            values = nvcValues;

            return true;
        }

        #endregion
    }
}

namespace Rhythm.Core
{

    // Namespaces.
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    /// <summary>
    /// A collection of extension methods to support the <see cref="NameValueCollection"/> interface.
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        #region Properties
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
        #endregion
    }
}

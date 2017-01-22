﻿namespace Rhythm.Core
{

    // The namespaces.
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods for collections.
    /// </summary>
    public static class CollectionExtensionMethods
    {

        #region Extension Methods

        /// <summary>
        /// Converts a null collection into an empty collection.
        /// </summary>
        /// <typeparam name="T">
        /// The type of item stored by the collection.
        /// </typeparam>
        /// <param name="items">
        /// The collection of items.
        /// </param>
        /// <returns>
        /// An empty list, if the supplied collection is null; otherwise, the supplied collection.
        /// </returns>
        public static IEnumerable<T> MakeSafe<T>(this IEnumerable<T> items)
        {
            return items == null
                ? Enumerable.Empty<T>()
                : items;
        }

        /// <summary>
        /// Returns the collection of items without any nulls.
        /// </summary>
        /// <typeparam name="T">
        /// The type of item stored by the collection.
        /// </typeparam>
        /// <param name="items">
        /// The collection of items.
        /// </param>
        /// <returns>
        /// The collection without null  items.
        /// </returns>
        public static IEnumerable<T> WithoutNulls<T>(this IEnumerable<T> items)
        {
            return items.Where(x => x != null);
        }

        /// <summary>
        /// Generates a sequence that conains the specified value the specified number of times.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value to be repeated in the result sequence.
        /// </typeparam>
        /// <param name="element">
        /// The value to be repeated.
        /// </param>
        /// <param name="count">
        /// The number of times to repeat the value in the generated sequence.
        /// </param>
        /// <returns>
        /// A collection containing the specified element the specified number of times.
        /// </returns>
        public static IEnumerable<T> Repeat<T>(this T element, int count)
        {
            return Enumerable.Repeat(element, count);
        }

        #endregion

    }

}
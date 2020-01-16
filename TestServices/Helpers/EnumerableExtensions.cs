// <copyright file="EnumerableExtensions.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An extension to IEnumerable. NOT WORKING!
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether [has same elements as] [the specified target].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>
        ///   <c>true</c> if [has same elements as] [the specified target]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasSameElementsAs<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            return source.Count() == target.Count() && source.All(a => target.Contains(a));
        }

        /// <summary>
        /// Determines whether the specified second has same. NOT WORKING!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        ///   <c>true</c> if the specified second has same; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasSame<T>(
            this IEnumerable<T> first,
            IEnumerable<T> second)
        {
            var firstMap = first
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());
            var secondMap = second
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());
            bool isSame = firstMap.Keys.All(x =>
                       secondMap.Keys.Contains(x) && firstMap[x] == secondMap[x]) &&
                secondMap.Keys.All(x =>
                    firstMap.Keys.Contains(x) && secondMap[x] == firstMap[x]);
            return isSame;
        }
    }
}

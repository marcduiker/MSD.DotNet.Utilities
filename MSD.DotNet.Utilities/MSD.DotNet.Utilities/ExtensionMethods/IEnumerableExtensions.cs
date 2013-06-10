using System;
using System.Collections.Generic;
using System.Linq;

namespace MSD.DotNet.Utilities.ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}

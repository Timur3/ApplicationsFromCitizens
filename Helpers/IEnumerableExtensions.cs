using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> e)
        {
            return e == null || !e.Any();
        }
    }
}
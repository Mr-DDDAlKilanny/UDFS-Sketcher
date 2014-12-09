using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher
{
    public static class Extensions
    {
        public static IEnumerable<T> FindAllDuplicates<T>(this IEnumerable<T> collection)
        {
            List<T> tmp = new List<T>();
            for (int i = 0; i < collection.Count(); ++i)
                for (int j = i + 1; j < collection.Count(); j++)
                    if (collection.ElementAt(i).Equals(collection.ElementAt(j)))
                        tmp.Add(collection.ElementAt(i));
            foreach (var item in tmp.Distinct())
                yield return item;
        }
    }
}

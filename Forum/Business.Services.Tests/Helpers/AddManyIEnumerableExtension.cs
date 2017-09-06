using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Tests.Helpers
{
    public static class AddManyIEnumerableExtension
    {
        public static void AddMany<T>(this ICollection<T> collection, params T[] parameters)
        {
            foreach (var p in parameters)
            {
                collection.Add(p);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Helpers
{
    public static class FindHelper<T> where T : class, IComparable<T>
    {
        /// <summary>
        /// Finds a specific <paramref name="entity"/> in a specific <paramref name="set"/>.
        /// Returns a found item if found and null if not
        /// </summary>
        /// <param name="set">Set where to search</param>
        /// <param name="entity">Entity to find</param>
        /// <returns>Entity if found or null if not</returns>
        public static async Task<T> FindEntityAsync(DbSet<T> set, T entity)
        {
            var list = await set.ToListAsync();
            return await Task.Run(() =>
            {
                return list.FirstOrDefault(x => x.CompareTo(entity).Equals(0));
            });
        }
        /// <summary>
        /// Finds a specific <paramref name="entity"/> in a specific <paramref name="collection"/>.
        /// Returns a found item if found and null if not
        /// </summary>
        /// <param name="collection">Collection where to search</param>
        /// <param name="entity">Entity to find</param>
        /// <returns>Entity if found or null if not</returns>
        public static async Task<T> FindEntityAsync(ICollection<T> collection, T entity)
        {
            return await Task.Run(() =>
            {
                return collection.FirstOrDefault(x => x.CompareTo(entity).Equals(0));
            });
        }
    }
}

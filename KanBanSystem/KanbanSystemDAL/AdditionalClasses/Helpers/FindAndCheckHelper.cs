using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Helpers
{
    /// <summary>
    /// <typeparamref name="T"/> can be: a class or a class which implements IComparable interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class FindAndCheckNullabilityHelper<T> where T : class, IComparable<T>
    {
        /// <summary>
        /// Find <paramref name="entity"/> in <paramref name="set"/>.
        /// Then compare it's nullability with <paramref name="mustBeNull"/>.
        /// If comprasion fails - throw exception with <paramref name="msg"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set"></param>
        /// <param name="entity"></param>
        /// <param name="msg"></param>
        /// <param name="mustBeNull"></param>
        /// <returns></returns>
        public static async Task<T> InDatabaseAsync(DbSet<T> set, T entity, string msg, bool mustBeNull)
        {
            var foundEntity = await FindEntityAsync(set, entity);
            foundEntity = CheckNullable(foundEntity, msg, mustBeNull);
            return foundEntity;
        }
        /// <summary>
        /// Find <paramref name="entity"/> in <paramref name="collection"/>.
        /// Then compare it's nullability with <paramref name="mustBeNull"/>.
        /// If comprasion fails - throw exception with <paramref name="msg"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="entity"></param>
        /// <param name="msg"></param>
        /// <param name="mustBeNull"></param>
        /// <returns></returns>
        public static async Task<T> InCollectionAsync(ICollection<T> collection, T entity, string msg, bool mustBeNull)
        {
            var foundEntity = await FindEntityAsync(collection, entity);
            foundEntity = CheckNullable(foundEntity, msg, mustBeNull);
            return foundEntity;
        }
        /// <summary>
        /// Check if <paramref name="obj"/> is null and compares with <paramref name="mustBeNull"/>.
        /// Returns <paramref name="obj"/> if comparison was successful.
        /// Throws exception with <paramref name="msg"/> if not.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        /// <param name="mustBeNull"></param>
        /// <returns><paramref name="obj"/> if check passed throws esception with <paramref name="msg"/> if not</returns>
        public static T CheckNullable(T obj, string msg, bool mustBeNull)
        {
            if (mustBeNull)
            {
                return obj == null ? obj : throw new Exception(msg);
            }
            else
            {
                return obj != null ? obj : throw new Exception(msg);
            }
        }
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

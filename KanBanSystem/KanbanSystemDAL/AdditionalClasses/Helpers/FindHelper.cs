using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Helpers
{
    public static class FindHelper<T> where T : class, IComparable<T>
    {
        public static async Task<T> FindEntityAsync(DbSet<T> set, T entity)
        {
            var list = await set.ToListAsync();
            return await Task.Run(() =>
            {
                return list.FirstOrDefault(x => x.CompareTo(entity).Equals(0));
            });
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Interfaces
{
    public interface IEntityInteraction<T> where T : class
    {
        Task<bool> AddEntityAsync(T entity);
        Task<bool> RemoveEntityAsync(T entity);
        Task<bool> UpdateEntityAsync(T entity);
        Task<IEnumerable<T>> GetEntitiesAsync();
    }
}

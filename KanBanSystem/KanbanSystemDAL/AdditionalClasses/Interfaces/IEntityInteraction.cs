using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Interfaces
{
    /// <summary>
    /// Interface for interaction with database. <typeparamref name="T">A type of entity to operate with<typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityInteraction<T> where T : class
    {
        /// <summary>
        /// Adds <paramref name="entity"/> to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddEntityAsync(T entity);
        /// <summary>
        /// Removes <paramref name="entity"/> from database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task RemoveEntityAsync(T entity);
        /// <summary>
        /// Returns all entities of type <typeparamref name="T"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetEntitiesAsync();
        /// <summary>
        /// Finds a specific <paramref name="entity"/> in database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> FindEntityAsync(T entity);
        /// <summary>
        /// Updates <paramref name="oldEntity"/> with values from <paramref name="newEntity"/>
        /// </summary>
        /// <param name="oldEntity">Old entity</param>
        /// <param name="newEntity">New entity from where to set values</param>
        Task<T> UpdateEntityAsync(T oldEntity, T newEntity);
    }
}

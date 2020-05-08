using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.AdditionalClasses.Interfaces;
using KanbanSystemDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Interaction
{
    /// <inheritdoc/>
    public abstract class ManagerBase<T> : IEntityInteraction<T> where T : class, IComparable<T>
    {
        KanbanSystemContext context;
        DbSet<T> set;
        public ManagerBase(KanbanSystemContext _context)
        {
            context = _context;
            set = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetEntitiesAsync()
        {
            return await set.ToArrayAsync();
        }
        public async Task<T> FindEntityAsync(T entity)
        {
            return await FindHelper<T>.FindEntityAsync(set, entity);
        }
        public async Task<T> UpdateEntityAsync(T oldEntity, T newEntity)
        {
            try
            {
                return await Task.Run(() =>
                {
                    oldEntity = UpdateHelper<T>.UpdateEntity(context, oldEntity, newEntity);
                    return oldEntity;
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddEntityAsync(T entity)
        {
            try
            {
                var found = await FindEntityAsync(entity);
                found = CheckNullHelper<T>.CheckNullable(found, $"Entity of type {entity.GetType()} is already in DB", true);
                set.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveEntityAsync(T entity)
        {
            try
            {
                var found = await FindEntityAsync(entity);
                found = CheckNullHelper<T>.CheckNullable(found, $"Entity of type {entity.GetType()} was not found", false);
                set.Remove(found);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

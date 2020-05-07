using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.AdditionalClasses.Interfaces;
using KanbanSystemDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.EntityInteraction
{
    public abstract class EntityInteractionBase<T> : IEntityInteraction<T> where T : class, IComparable<T>
    {
        KanbanSystemContext context;
        DbSet<T> set;
        public EntityInteractionBase(KanbanSystemContext _context)
        {
            context = _context;
            set = context.Set<T>();
        }
        public async Task<bool> AddEntityAsync(T entity)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var flag = false;
                    var found = await FindHelper<T>.FindEntityAsync(set, entity);
                    if (found == null)
                    {
                        set.Add(entity);
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                    return flag;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync()
        {
            return await set.ToArrayAsync();
        }

        public async Task<bool> RemoveEntityAsync(T entity)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var flag = false;
                    var found = await FindHelper<T>.FindEntityAsync(set, entity);
                    if (found != null)
                    {
                        set.Remove(entity);
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                    return flag;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }

        public async Task<bool> UpdateEntityAsync(T entity)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var flag = false;
                    var found = await FindHelper<T>.FindEntityAsync(set, entity);
                    if (found != null)
                    {
                        found = UpdateHelper<T>.UpdateEntity(context, found, entity);
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                    return flag;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
    }
}

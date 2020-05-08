using KanbanSystemDAL.Model;
using System.Data.Entity;

namespace KanbanSystemDAL.AdditionalClasses.Helpers
{
    public static class UpdateHelper<T> where T : class
    {
        /// <summary>
        /// Updates in <paramref name="context"/> an <paramref name="oldEntity"/> with values from <paramref name="newEntity"/>
        /// </summary>
        /// <param name="context">Context to work in</param>
        /// <param name="oldEntity">Old entity</param>
        /// <param name="newEntity">New entity from where to set values</param>
        /// <returns></returns>
        public static T UpdateEntity(KanbanSystemContext context, T oldEntity, T newEntity)
        {
            context.Entry(oldEntity).State = EntityState.Detached;
            var type = oldEntity.GetType();
            var properties = type.GetProperties();
            object propValue = null;
            var propName = "";
            foreach (var p in properties)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    propName = properties[i].Name;
                    if (i == 0 && propName.Contains("Id"))
                    {
                        continue;
                    }
                    propValue = type.GetProperty(propName).GetValue(newEntity);
                    properties[i].SetValue(oldEntity, propValue);
                }
            }
            context.Entry(oldEntity).State = EntityState.Modified;
            return oldEntity;
        }
    }
}

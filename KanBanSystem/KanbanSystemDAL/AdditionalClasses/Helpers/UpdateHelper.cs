using KanbanSystemDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Helpers
{
    public static class UpdateHelper<T> where T: class
    {
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

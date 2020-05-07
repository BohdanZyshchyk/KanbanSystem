using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfServiceInteraction.ServiceInterfaces
{
    [ServiceContract]
    public interface IEntityService<T> where T : class
    {
        [OperationContract]
        Task<bool> AddEntityAsync(T entity);
        [OperationContract]
        Task<IEnumerable<T>> GetEntitiesAsync(T entity);
        Task<bool> RemoveEntityAsync(T entity);
        [OperationContract]
        Task<bool> UpdateEntityAsync(T entity);
        [OperationContract]
    }
}

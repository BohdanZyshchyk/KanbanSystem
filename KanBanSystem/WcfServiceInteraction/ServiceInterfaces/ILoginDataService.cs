using System.ServiceModel;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.ServiceInterfaces
{
    [ServiceContract]
    public interface ILoginDataService : IEntityService<LoginDataDTO>
    {
    }
}

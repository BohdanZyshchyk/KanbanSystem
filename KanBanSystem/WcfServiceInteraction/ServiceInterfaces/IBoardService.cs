using System.ServiceModel;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.ServiceInterfaces
{
    [ServiceContract]
    public interface IBoardService : IEntityService<BoardDTO>
    {
    }
}

using System.ServiceModel;
using WcfServiceInteraction.CallbackInterfaces;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.ServiceInterfaces
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IUserManagerService
    {
        [OperationContract]
        void RegisterAsync(UserDTO user);
        [OperationContract]
        void LoginAsync(LoginDataDTO loginData);
    }
}

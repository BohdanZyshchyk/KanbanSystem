using System.ServiceModel;
using System.Threading.Tasks;
using WcfServiceInteraction.CallbackInterfaces;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.ServiceInterfaces
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IUserManagerService
    {
        /// <summary>
        /// Register a new <paramref name="user"/>
        /// </summary>
        /// <param name="user"></param>
        [OperationContract]
        void Register(UserDTO user);
        /// <summary>
        /// Login into system using <paramref name="loginData"/>
        /// </summary>
        /// <param name="loginData"></param>
        [OperationContract]
        Task<UserDTO> Login(LoginDataDTO loginData);
    }
}

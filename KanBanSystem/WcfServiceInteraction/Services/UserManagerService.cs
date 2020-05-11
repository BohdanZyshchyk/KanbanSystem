using KanbanSystemDAL.AdditionalClasses;
using KanbanSystemDAL.Model;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using WcfServiceInteraction.CallbackInterfaces;
using WcfServiceInteraction.DTO;
using WcfServiceInteraction.Helpers;
using WcfServiceInteraction.ServiceInterfaces;

namespace WcfServiceInteraction.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class UserManagerService : IUserManagerService
    {
        KanbanSystemContextRepository repository;
        IServiceCallback serviceCallback;
        public UserManagerService()
        {
            repository = new KanbanSystemContextRepository();
            serviceCallback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
        }
        public async Task<UserDTO> LoginAsync(LoginDataDTO loginData)
        {
            try
            {
                var ld = MapperHelper.GetLoginDataFromDTO(loginData);
                var user = await repository.UserManager.LoginAsync(ld);
                var userDTO = MapperHelper.UserMapper.Map<User, UserDTO>(user);
                SendCallback("Login was successful!", true);
                return userDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RegisterAsync(UserDTO user)
        {
            try
            {
                var u = MapperHelper.GetUserFromDTO(user);
                await repository.UserManager.RegisterAsync(u);
                await CommitChangesAsync();
                SendCallback("Registration was successful!", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task CommitChangesAsync()
        {
            await repository.CommitChangesAsync();
        }
        private void SendCallback(string message, bool login)
        {
            switch (login)
            {
                case true:
                    {
                        serviceCallback.InformAboutLogin(message);
                        break;
                    }
                case false:
                    {
                        serviceCallback.InformAboutRegistration(message);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}

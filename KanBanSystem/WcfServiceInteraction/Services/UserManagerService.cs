using KanbanSystemDAL.AdditionalClasses;
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
        public async Task<UserDTO> Login(LoginDataDTO loginData)
        {
            try
            {
                var ld = MapperBroker.GetLoginDataFromDTO(loginData);
                var user = await repository.UserManager.LoginAsync(ld);
                var userDTO = MapperBroker.GetUserDTOFromEntity(user);
                return userDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void Register(UserDTO user)
        {
            try
            {
                var u = MapperBroker.GetUserFromDTO(user);
                await repository.UserManager.RegisterAsync(u);
                await CommitChangesAsync();
                SendCallback($"Welcome to our system, {user.Name}! Registration was successful! You will be redirected to login window now. Use your login data to enter");
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
        private void SendCallback(string message)
        {
            serviceCallback.InformAboutRegistration(message);
        }
    }
}

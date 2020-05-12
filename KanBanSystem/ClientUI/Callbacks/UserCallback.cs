using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientUI.KrabServicesUserManager;
using ClientUI.View;

namespace ClientUI.Callbacks
{
    public class UserCallback : IUserManagerServiceCallback
    {
        UserRegistrationWindow window;
        public UserCallback(UserRegistrationWindow window)
        {
            this.window = window;
        }
        public void InformAboutRegistration(string message)
        {
            window.InformAboutRegistration(message);
            window.RedirectToLoginWindow();
        }

        public void RefreshBoards(BoardDTO[] boards)
        {
            throw new NotImplementedException();
        }
    }
}

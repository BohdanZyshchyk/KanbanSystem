using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientUI.KrabServicesUserManager;

namespace ClientUI.Callbacks
{
    public class UserCallback : IUserManagerServiceCallback
    {
        public void InformAboutLogin(string message)
        {
            throw new NotImplementedException();
        }

        public void InformAboutRegistration(string message)
        {
            throw new NotImplementedException();
        }

        public void RefreshBoards(BoardDTO[] boards)
        {
            throw new NotImplementedException();
        }
    }
}

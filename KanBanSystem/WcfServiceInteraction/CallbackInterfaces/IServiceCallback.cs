using System.Collections.Generic;
using System.ServiceModel;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.CallbackInterfaces
{
    public interface IServiceCallback
    {
        /// <summary>
        /// Get all <paramref name="boards"/> from database
        /// </summary>
        /// <param name="boards"></param>
        [OperationContract]
        void RefreshBoards(IEnumerable<BoardDTO> boards);
        /// <summary>
        /// Infrom a user about registration with <paramref name="message"/>
        /// </summary>
        /// <param name="message"></param>
        [OperationContract]
        void InformAboutRegistration(string message);
    }
}

using System.Collections.Generic;
using System.ServiceModel;
using WcfServiceInteraction.CallbackInterfaces;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.ServiceInterfaces
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IBoardManagerService
    {
        [OperationContract]
        IEnumerable<BoardDTO> GetBoardsAsync();
        [OperationContract]
        BoardDTO UpdateBoardAsync(BoardDTO oldBoard, BoardDTO newBoard);
        [OperationContract]
        void AddBoardAsync(BoardDTO board);
        [OperationContract]
        void RemoveBoardAsync(BoardDTO board);
    }
}

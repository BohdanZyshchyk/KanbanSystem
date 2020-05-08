using System.ServiceModel;
using System.Threading.Tasks;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.ServiceInterfaces
{
    [ServiceContract]
    public interface IBoardInteractionService
    {
        [OperationContract]
        Task AddUserToBoardAsync(BoardDTO board, UserDTO user);
        [OperationContract]
        Task RemoveUserFromBoardAsync(BoardDTO board, UserDTO user);
        [OperationContract]
        Task AddCardListToBoardAsync(BoardDTO board, CardListDTO cardList);
        [OperationContract]
        Task RemoveCardListFromBoardAsync(BoardDTO board, CardListDTO cardList);
        [OperationContract]
        Task RenameBoardAsync(BoardDTO board, string newName);
    }
}

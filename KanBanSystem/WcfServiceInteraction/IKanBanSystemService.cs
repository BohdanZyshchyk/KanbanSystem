using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction
{
    [ServiceContract]
    public interface IKanBanSystemService
    {
        #region ADDs
        [OperationContract]
        Task<bool> AddBoardAsync(BoardDTO board);
        [OperationContract]
        Task<bool> AddCardAsync(CardDTO card);
        [OperationContract]
        Task<bool> AddCardActivityAsync(CardActivityDTO cardActivity);
        [OperationContract]
        Task<bool> AddCardListAsync(CardListDTO cardList);
        [OperationContract]
        Task<bool> AddCommentAsync(CommentDTO comment);
        [OperationContract]
        Task<bool> AddLabelColorAsync(LabelColorDTO labelColor);
        [OperationContract]
        Task<bool> AddLoginDataAsync(LoginDataDTO loginData);
        [OperationContract]
        Task<bool> AddUserAsync(UserDTO user);
        #endregion

        #region REMOVEs
        [OperationContract]
        Task<bool> RemoveBoardAsync(BoardDTO board);
        [OperationContract]
        Task<bool> RemoveCardAsync(CardDTO card);
        [OperationContract]
        Task<bool> RemoveCardActivityAsync(CardActivityDTO cardActivity);
        [OperationContract]
        Task<bool> RemoveCardListAsync(CardListDTO cardList);
        [OperationContract]
        Task<bool> RemoveCommentAsync(CommentDTO comment);
        [OperationContract]
        Task<bool> RemoveLabelColorAsync(LabelColorDTO labelColor);
        [OperationContract]
        Task<bool> RemoveLoginDataAsync(LoginDataDTO loginData);
        [OperationContract]
        Task<bool> RemoveUserAsync(UserDTO user);
        #endregion

        #region UPDATEs
        [OperationContract]
        Task<bool> UpdateBoardAsync(BoardDTO board);
        [OperationContract]
        Task<bool> UpdateCardAsync(CardDTO card);
        [OperationContract]
        Task<bool> UpdateCardActivityAsync(CardActivityDTO cardActivity);
        [OperationContract]
        Task<bool> UpdateCardListAsync(CardListDTO cardList);
        [OperationContract]
        Task<bool> UpdateCommentAsync(CommentDTO comment);
        [OperationContract]
        Task<bool> UpdateLabelColorAsync(LabelColorDTO labelColor);
        [OperationContract]
        Task<bool> UpdateLoginDataAsync(LoginDataDTO loginData);
        [OperationContract]
        Task<bool> UpdateUserAsync(UserDTO user);
        #endregion

        #region GETs
        [OperationContract]
        Task<IEnumerable<BoardDTO>> GetBoardsAsync();
        [OperationContract]
        Task<IEnumerable<CardDTO>> GetCardsAsync();
        [OperationContract]
        Task<IEnumerable<CardActivityDTO>> GetCardActivitiesAsync();
        [OperationContract]
        Task<IEnumerable<CardListDTO>> GetCardListsAsync();
        [OperationContract]
        Task<IEnumerable<CommentDTO>> GetCommentsAsync();
        [OperationContract]
        Task<IEnumerable<LabelColorDTO>> GetLabelColorsAsync();
        [OperationContract]
        Task<IEnumerable<LoginDataDTO>> GetLoginDatasAsync();
        [OperationContract]
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        #endregion

    }
}

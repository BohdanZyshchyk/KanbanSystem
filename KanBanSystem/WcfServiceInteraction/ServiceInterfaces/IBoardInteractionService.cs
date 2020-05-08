using System;
using System.ServiceModel;
using WcfServiceInteraction.CallbackInterfaces;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.ServiceInterfaces
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IBoardInteractionService
    {
        #region Board Interaction
        [OperationContract]
        void AddUserToBoard(BoardDTO board, UserDTO user);
        [OperationContract]
        void RemoveUserFromBoard(BoardDTO board, UserDTO user);
        [OperationContract]
        void AddCardListToBoard(BoardDTO board, CardListDTO cardList);
        [OperationContract]
        void RemoveCardListFromBoard(BoardDTO board, CardListDTO cardList);
        [OperationContract]
        void RenameBoard(BoardDTO board, string newName);
        #endregion

        #region Cardlist interaction
        [OperationContract]
        void AddCardToCardListAsync(CardListDTO cardList, CardDTO card);
        [OperationContract]
        void RemoveCardFromCardListAsync(CardListDTO cardList, CardDTO card);
        [OperationContract]
        void RenameCardListAsync(CardListDTO cardList, string newName);
        #endregion

        #region Card interaction
        [OperationContract]
        void AddUserToCard(CardDTO card, UserDTO user);
        [OperationContract]
        void RemoveUserFromCard(CardDTO card, UserDTO user);
        [OperationContract]
        void AddLabelColorToCard(CardDTO card, LabelColorDTO labelColor);
        [OperationContract]
        void RemoveLabelColorFromCard(CardDTO card, LabelColorDTO labelColor);
        [OperationContract]
        void AddCommentToCard(CardDTO card, CommentDTO comment);
        [OperationContract]
        void RemoveCommentFromCard(CardDTO card, CommentDTO comment);
        [OperationContract]
        void ChangeDueDateOfACard(CardDTO card, DateTime date);
        [OperationContract]
        void ChangeNameOfACard(CardDTO card, string newName);
        #endregion
    }
}

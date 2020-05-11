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
        /// <summary>
        /// Assign a <paramref name="user"/> to a <paramref name="board"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="user"></param>
        [OperationContract]
        void AddUserToBoard(BoardDTO board, UserDTO user);
        /// <summary>
        /// Remove a <paramref name="user"/> from a <paramref name="board"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="user"></param>
        [OperationContract]
        void RemoveUserFromBoard(BoardDTO board, UserDTO user);
        /// <summary>
        /// Add a <paramref name="cardList"/> to a <paramref name="board"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="cardList"></param>
        [OperationContract]
        void AddCardListToBoard(BoardDTO board, CardListDTO cardList);
        /// <summary>
        /// Remove a <paramref name="cardList"/> from a <paramref name="board"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="cardList"></param>
        [OperationContract]
        void RemoveCardListFromBoard(BoardDTO board, CardListDTO cardList);
        /// <summary>
        /// Rename a <paramref name="board"/> with a new <paramref name="newName"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="newName"></param>
        [OperationContract]
        void RenameBoard(BoardDTO board, string newName);
        #endregion

        #region Cardlist interaction
        /// <summary>
        /// Add a <paramref name="card"/> to a <paramref name="cardList"/>
        /// </summary>
        /// <param name="cardList"></param>
        /// <param name="card"></param>
        [OperationContract]
        void AddCardToCardListAsync(CardListDTO cardList, CardDTO card);
        /// <summary>
        /// Remove a <paramref name="card"/> from a <paramref name="cardList"/>
        /// </summary>
        /// <param name="cardList"></param>
        /// <param name="card"></param>
        [OperationContract]
        void RemoveCardFromCardListAsync(CardListDTO cardList, CardDTO card);
        /// <summary>
        /// Rename a <paramref name="cardList"/> with new <paramref name="newName"/>
        /// </summary>
        /// <param name="cardList"></param>
        /// <param name="newName"></param>
        [OperationContract]
        void RenameCardList(CardListDTO cardList, string newName);
        #endregion

        #region Card interaction
        /// <summary>
        /// Assign a <paramref name="user"/> to a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="user"></param>
        [OperationContract]
        void AddUserToCard(CardDTO card, UserDTO user);
        /// <summary>
        /// Remove a <paramref name="user"/> from a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="user"></param>
        [OperationContract]
        void RemoveUserFromCard(CardDTO card, UserDTO user);
        /// <summary>
        /// Add a <paramref name="labelColor"/> to a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="labelColor"></param>
        [OperationContract]
        void AddLabelColorToCard(CardDTO card, LabelColorDTO labelColor);
        /// <summary>
        /// Remove <paramref name="labelColor"/> from a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="labelColor"></param>
        [OperationContract]
        void RemoveLabelColorFromCard(CardDTO card, LabelColorDTO labelColor);
        /// <summary>
        /// Add a <paramref name="comment"/> to a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="comment"></param>
        [OperationContract]
        void AddCommentToCard(CardDTO card, CommentDTO comment);
        /// <summary>
        /// Remove <paramref name="comment"/> from a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="comment"></param>
        [OperationContract]
        void RemoveCommentFromCard(CardDTO card, CommentDTO comment);
        /// <summary>
        /// Change due date of a task in the <paramref name="card"/> using new <paramref name="date"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="date"></param>
        [OperationContract]
        void ChangeDueDateOfACard(CardDTO card, DateTime date);
        /// <summary>
        /// Rename a <paramref name="card"/> with new <paramref name="newName"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="newName"></param>
        [OperationContract]
        void ChangeNameOfACard(CardDTO card, string newName);
        #endregion
    }
}

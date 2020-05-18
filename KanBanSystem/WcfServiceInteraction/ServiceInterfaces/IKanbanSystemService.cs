using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WcfServiceInteraction.CallbackInterfaces;
using WcfServiceInteraction.DTO;
using WcfServiceInteraction.Services.AdditionalClasses;

namespace WcfServiceInteraction.ServiceInterfaces
{
    /// <inheritdoc/>
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IKanbanSystemService
    {
        #region Board ineraction methods
        #region Board Interaction
        /// <summary>
        /// Assign a <paramref name="user"/> to a <paramref name="board"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="user"></param>
        [OperationContract]
        void AddUserToBoard(BoardDTO board, UserInfo user);
        /// <summary>
        /// Remove a <paramref name="user"/> from a <paramref name="board"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="user"></param>
        [OperationContract]
        void RemoveUserFromBoard(BoardDTO board, UserInfo user);
        /// <summary>
        /// Add a <paramref name="cardList"/> to a <paramref name="board"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="cardList"></param>
        [OperationContract]
        void AddCardListToBoard(BoardDTO board, CardListDTO cardList, string token);
        /// <summary>
        /// Remove a <paramref name="cardList"/> from a <paramref name="board"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="cardList"></param>
        [OperationContract]
        void RemoveCardListFromBoard(BoardDTO board, CardListDTO cardList, string token);
        /// <summary>
        /// Rename a <paramref name="board"/> with a new <paramref name="newName"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="newName"></param>
        [OperationContract]
        void RenameBoard(BoardDTO board, string newName, string token);
        #endregion

        #region Cardlist interaction
        /// <summary>
        /// Add a <paramref name="card"/> to a <paramref name="cardList"/>
        /// </summary>
        /// <param name="cardList"></param>
        /// <param name="card"></param>
        [OperationContract]
        void AddCardToCardList(CardListDTO cardList, CardDTO card, string token);
        /// <summary>
        /// Remove a <paramref name="card"/> from a <paramref name="cardList"/>
        /// </summary>
        /// <param name="cardList"></param>
        /// <param name="card"></param>
        [OperationContract]
        void RemoveCardFromCardList(CardListDTO cardList, CardDTO card, string token);
        /// <summary>
        /// Rename a <paramref name="cardList"/> with new <paramref name="newName"/>
        /// </summary>
        /// <param name="cardList"></param>
        /// <param name="newName"></param>
        [OperationContract]
        void RenameCardList(CardListDTO cardList, string newName, string token);
        #endregion

        #region Card interaction
        /// <summary>
        /// Assign a <paramref name="user"/> to a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="user"></param>
        [OperationContract]
        void AddUserToCard(CardDTO card, UserInfo user);
        /// <summary>
        /// Remove a <paramref name="user"/> from a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="user"></param>
        [OperationContract]
        void RemoveUserFromCard(CardDTO card, UserInfo user);
        /// <summary>
        /// Add a <paramref name="labelColor"/> to a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="labelColor"></param>
        [OperationContract]
        void AddLabelColorToCard(CardDTO card, LabelColorDTO labelColor, string token);
        /// <summary>
        /// Remove <paramref name="labelColor"/> from a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="labelColor"></param>
        [OperationContract]
        void RemoveLabelColorFromCard(CardDTO card, LabelColorDTO labelColor, string token);
        /// <summary>
        /// Add a <paramref name="comment"/> to a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="comment"></param>
        [OperationContract]
        void AddCommentToCard(CardDTO card, CommentDTO comment, string token);
        /// <summary>
        /// Remove <paramref name="comment"/> from a <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="comment"></param>
        [OperationContract]
        void RemoveCommentFromCard(CardDTO card, CommentDTO comment, string token);
        /// <summary>
        /// Change due date of a task in the <paramref name="card"/> using new <paramref name="date"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="date"></param>
        [OperationContract]
        void ChangeDueDateOfACard(CardDTO card, DateTime date, string token);
        /// <summary>
        /// Rename a <paramref name="card"/> with new <paramref name="newName"/>
        /// </summary>
        /// <param name="card"></param>
        /// <param name="newName"></param>
        [OperationContract]
        void ChangeNameOfACard(CardDTO card, string newName, string token);
        #endregion
        #endregion

        #region Board manager methods
        /// <summary>
        /// Get all boards from database
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Task<IEnumerable<BoardDTO>> GetBoards();
        /// <summary>
        /// Update an <paramref name="oldBoard"/> with data from <paramref name="newBoard"/>
        /// </summary>
        /// <param name="oldBoard"></param>
        /// <param name="newBoard"></param>
        /// <returns></returns>
        [OperationContract]
        Task<BoardDTO> UpdateBoard(BoardDTO oldBoard, BoardDTO newBoard, string token);
        /// <summary>
        /// Add a new <paramref name="board"/> to database
        /// </summary>
        /// <param name="board"></param>
        [OperationContract]
        void AddBoard(BoardDTO board, string token);
        /// <summary>
        /// Remove a specific <paramref name="board"/> from database
        /// </summary>
        /// <param name="board"></param>
        [OperationContract]
        void RemoveBoard(BoardDTO board, string token);
        #endregion

        #region User manager methods
        /// <summary>
        /// Register a new <paramref name="user"/>
        /// </summary>
        /// <param name="user"></param>
        [OperationContract]
        Task<bool> Register(UserDTO user);
        /// <summary>
        /// Login into system using <paramref name="loginData"/>
        /// </summary>
        /// <param name="loginData"></param>
        [OperationContract]
        Task<UserInfo> Login(UserDTO user);
        /// <summary>
        /// Logout from system
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [OperationContract]
        bool Logout(UserInfo user);
        #endregion
    }
}

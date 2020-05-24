using KanbanSystemDAL.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using WcfServiceInteraction.CallbackInterfaces;
using WcfServiceInteraction.DTO;
using WcfServiceInteraction.Helpers;
using WcfServiceInteraction.ServiceInterfaces;
using WcfServiceInteraction.Services.AdditionalClasses;

namespace WcfServiceInteraction.Services
{
    /// <inheritdoc/>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class KanbanSystemService : IKanbanSystemService
    {
        KanbanSystemContextRepository repository;
        KanbanSystemServiceClient lastRegistred;
        ICollection<KanbanSystemServiceClient> SystemServiceClients { get; set; }
        ICollection<string> Tokens { get; set; }
        public KanbanSystemService()
        {
            repository = new KanbanSystemContextRepository();
            SystemServiceClients = new List<KanbanSystemServiceClient>();
            Tokens = new List<string>();
        }
        #region Board interaction
        public async void AddCardListToBoard(BoardDTO board, CardListDTO cardList, string token)
        {
            try
            {
                CheckToken(token);
                var b = MapperBroker.GetBoardFromDTO(board);
                var cl = MapperBroker.GetCardListFromDTO(cardList);
                await repository.BoardInteraction.AddCardListToBoardAsync(b, cl);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void AddCardToCardList(CardListDTO cardList, CardDTO card, string token)
        {
            try
            {
                CheckToken(token);
                var cl = MapperBroker.GetCardListFromDTO(cardList);
                var c = MapperBroker.GetCardFromDTO(card);
                await repository.CardListInteraction.AddCardToCardListAsync(cl, c);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void AddCommentToCard(CardDTO card, CommentDTO comment, string token)
        {
            try
            {
                CheckToken(token);
                var c = MapperBroker.GetCardFromDTO(card);
                var cm = MapperBroker.GetCommentFromDTO(comment);
                await repository.CardManager.AddCommentToCardAsync(c, cm);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void AddLabelColorToCard(CardDTO card, LabelColorDTO labelColor, string token)
        {
            try
            {
                CheckToken(token);
                var c = MapperBroker.GetCardFromDTO(card);
                var lc = MapperBroker.GetLabelColorFromDTO(labelColor);
                await repository.CardManager.AddLabelColorToCardAsync(c, lc);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void AddUserToBoard(BoardDTO board, UserInfo user)
        {
            try
            {
                CheckToken(user.Token);
                var b = MapperBroker.GetBoardFromDTO(board);
                var u = MapperBroker.GetUserFromDTO(user.User);
                await repository.BoardInteraction.AddUserToBoardAsync(b, u);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async void AddUserToCard(CardDTO card, UserInfo user)
        {
            try
            {
                CheckToken(user.Token);
                var c = MapperBroker.GetCardFromDTO(card);
                var u = MapperBroker.GetUserFromDTO(user.User);
                await repository.CardManager.AddUserToCardAsync(c, u);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void ChangeDueDateOfACard(CardDTO card, DateTime date, string token)
        {
            try
            {
                CheckToken(token);
                var c = MapperBroker.GetCardFromDTO(card);
                await repository.CardManager.ChangeDueDateOfACardAsync(c, date);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void ChangeNameOfACard(CardDTO card, string newName, string token)
        {
            try
            {
                CheckToken(token);
                var c = MapperBroker.GetCardFromDTO(card);
                await repository.CardManager.ChangeNameOfACardAsync(c, newName);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveCardFromCardList(CardListDTO cardList, CardDTO card, string token)
        {
            try
            {
                CheckToken(token);
                var cl = MapperBroker.GetCardListFromDTO(cardList);
                var c = MapperBroker.GetCardFromDTO(card);
                await repository.CardListInteraction.RemoveCardFromCardListAsync(cl, c);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveCardListFromBoard(BoardDTO board, CardListDTO cardList, string token)
        {
            try
            {
                CheckToken(token);
                var b = MapperBroker.GetBoardFromDTO(board);
                var cl = MapperBroker.GetCardListFromDTO(cardList);
                await repository.BoardInteraction.RemoveCardListFromBoardAsync(b, cl);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveCommentFromCard(CardDTO card, CommentDTO comment, string token)
        {
            try
            {
                CheckToken(token);
                var c = MapperBroker.GetCardFromDTO(card);
                var cm = MapperBroker.GetCommentFromDTO(comment);
                await repository.CardManager.RemoveCommentFromCardAsync(c, cm);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveLabelColorFromCard(CardDTO card, LabelColorDTO labelColor, string token)
        {
            try
            {
                CheckToken(token);
                var c = MapperBroker.GetCardFromDTO(card);
                var lc = MapperBroker.GetLabelColorFromDTO(labelColor);
                await repository.CardManager.RemoveLabelColorFromCardAsync(c, lc);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveUserFromBoard(BoardDTO board, UserInfo user)
        {
            try
            {
                CheckToken(user.Token);
                var b = MapperBroker.GetBoardFromDTO(board);
                var u = MapperBroker.GetUserFromDTO(user.User);
                await repository.BoardInteraction.RemoveUserFromBoardAsync(b, u);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveUserFromCard(CardDTO card, UserInfo user)
        {
            try
            {
                CheckToken(user.Token);
                var c = MapperBroker.GetCardFromDTO(card);
                var u = MapperBroker.GetUserFromDTO(user.User);
                await repository.CardManager.RemoveUserFromCardAsync(c, u);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RenameBoard(BoardDTO board, string newName, string token)
        {
            try
            {
                CheckToken(token);
                var b = MapperBroker.GetBoardFromDTO(board);
                await repository.BoardInteraction.RenameBoardAsync(b, newName);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RenameCardList(CardListDTO cardList, string newName, string token)
        {
            try
            {
                CheckToken(token);
                var cl = MapperBroker.GetCardListFromDTO(cardList);
                await repository.CardListInteraction.RenameCardListAsync(cl, newName);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Board manager
        public async void AddBoard(BoardDTO board, string token)
        {
            try
            {
                CheckToken(token);
                var b = MapperBroker.GetBoardFromDTO(board);
                await repository.BoardManager.AddEntityAsync(b);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<BoardDTO>> GetBoards()
        {
            try
            {
                var boards = await repository.BoardManager.GetEntitiesAsync();
                var boardDTOs = MapperBroker.GetBoardDTOsFromBoards(boards);
                return boardDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveBoard(BoardDTO board, string token)
        {
            try
            {
                CheckToken(token);
                var b = MapperBroker.GetBoardFromDTO(board);
                await repository.BoardManager.RemoveEntityAsync(b);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BoardDTO> UpdateBoard(BoardDTO oldBoard, BoardDTO newBoard, string token)
        {
            try
            {
                CheckToken(token);
                var oldB = MapperBroker.GetBoardFromDTO(oldBoard);
                var newB = MapperBroker.GetBoardFromDTO(newBoard);
                oldB = await repository.BoardManager.UpdateEntityAsync(oldB, newB);
                await CommitAndSendCallbackAsync();
                return MapperBroker.GetBoardDTOFromEntity(oldB);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region User manager
        public async Task<UserInfo> Login(UserDTO user)
        {
            try
            {
                var u = MapperBroker.GetUserFromDTO(user);
                u = await repository.UserManager.LoginAsync(u);
                var userDTO = MapperBroker.GetUserDTOFromEntity(u);
                var info = new UserInfo { User = userDTO, Token = Guid.NewGuid().ToString() };
                Tokens.Add(info.Token);
                return info;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Register(UserDTO user)
        {
            try
            {
                var u = MapperBroker.GetUserFromDTO(user);
                var current = OperationContext.Current;
                await repository.UserManager.RegisterAsync(u);
                lastRegistred = new KanbanSystemServiceClient { ClientName = user.UserName, Callback = current.GetCallbackChannel<IServiceCallback>() };
                SystemServiceClients.Add(lastRegistred);
                await CommitAndSendCallbackAsync(true);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Logout(UserInfo user)
        {
            CheckToken(user.Token);
            var token = "";
            KanbanSystemServiceClient client = null;
            foreach (var ssc in SystemServiceClients)
            {
                if (ssc.ClientName.Equals(user.User.UserName))
                {
                    client = ssc;
                    SystemServiceClients.Remove(client);
                    break;
                }
            }
            foreach (var t in Tokens)
            {
                if (t.Equals(user.Token))
                {
                    token = t;
                    Tokens.Remove(token);
                    break;
                }
            }
            return true;
        }
        private void CheckToken(string token)
        {
            if (!Tokens.Any(x => x.Equals(token)))
            {
                throw new Exception("Only a loged in user has right for this action!");
            }
        }
        #endregion

        #region Commit and send callbacks
        private async Task<bool> CommitChangesAsync()
        {
            return await repository.CommitChangesAsync();
        }
        private async Task SendCallback(bool isRegistration)
        {
            if (isRegistration)
            {
                lastRegistred.Callback.InformAboutRegistration($"Welcome to our system, {lastRegistred.ClientName}! Registration was successful! You will be redirected to login window now. Use your login data to enter");
            }
            else
            {
                var boards = await repository.BoardManager.GetEntitiesAsync();
                var boardDTOs = MapperBroker.GetBoardDTOsFromBoards(boards);
                foreach (var sc in SystemServiceClients)
                {
                    sc.Callback.RefreshBoards(boardDTOs);
                }
            }
        }
        private async Task CommitAndSendCallbackAsync(bool isRegistration = false)
        {
            var res = await CommitChangesAsync();
            if (res)
                await SendCallback(isRegistration);
        }

        
        #endregion
    }
}

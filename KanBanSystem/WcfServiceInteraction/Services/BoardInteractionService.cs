using KanbanSystemDAL.AdditionalClasses;
using KanbanSystemDAL.Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WcfServiceInteraction.CallbackInterfaces;
using WcfServiceInteraction.DTO;
using WcfServiceInteraction.Helpers;
using WcfServiceInteraction.ServiceInterfaces;

namespace WcfServiceInteraction.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class BoardInteractionService : IBoardInteractionService
    {
        KanbanSystemContextRepository repository;
        IServiceCallback serviceCallback;
        public BoardInteractionService()
        {
            repository = new KanbanSystemContextRepository();
            serviceCallback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
        }
        public async void AddCardListToBoard(BoardDTO board, CardListDTO cardList)
        {
            try
            {
                var b = GetBoardFromDTO(board);
                var cl = GetCardListFromDTO(cardList);
                await repository.BoardInteraction.AddCardListToBoardAsync(b, cl);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void AddCardToCardListAsync(CardListDTO cardList, CardDTO card)
        {
            try
            {
                var cl = GetCardListFromDTO(cardList);
                var c = GetCardFromDTO(card);
                await repository.CardListInteraction.AddCardToCardListAsync(cl, c);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void AddCommentToCard(CardDTO card, CommentDTO comment)
        {
            try
            {
                var c = GetCardFromDTO(card);
                var cm = GetCommentFromDTO(comment);
                await repository.CardManager.AddCommentToCardAsync(c, cm);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void AddLabelColorToCard(CardDTO card, LabelColorDTO labelColor)
        {
            try
            {
                var c = GetCardFromDTO(card);
                var lc = GetLabelColorFromDTO(labelColor);
                await repository.CardManager.AddLabelColorToCardAsync(c, lc);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void AddUserToBoard(BoardDTO board, UserDTO user)
        {
            try
            {
                var b = GetBoardFromDTO(board);
                var u = GetUserFromDTO(user);
                await repository.BoardInteraction.AddUserToBoardAsync(b, u);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async void AddUserToCard(CardDTO card, UserDTO user)
        {
            try
            {
                var c = GetCardFromDTO(card);
                var u = GetUserFromDTO(user);
                await repository.CardManager.AddUserToCardAsync(c, u);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void ChangeDueDateOfACard(CardDTO card, DateTime date)
        {
            try
            {
                var c = GetCardFromDTO(card);
                await repository.CardManager.ChangeDueDateOfACardAsync(c, date);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void ChangeNameOfACard(CardDTO card, string newName)
        {
            try
            {
                var c = GetCardFromDTO(card);
                await repository.CardManager.ChangeNameOfACardAsync(c, newName);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveCardFromCardListAsync(CardListDTO cardList, CardDTO card)
        {
            try
            {
                var cl = GetCardListFromDTO(cardList);
                var c = GetCardFromDTO(card);
                await repository.CardListInteraction.RemoveCardFromCardListAsync(cl, c);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveCardListFromBoard(BoardDTO board, CardListDTO cardList)
        {
            try
            {
                var b = GetBoardFromDTO(board);
                var cl = GetCardListFromDTO(cardList);
                await repository.BoardInteraction.RemoveCardListFromBoardAsync(b, cl);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveCommentFromCard(CardDTO card, CommentDTO comment)
        {
            try
            {
                var c = GetCardFromDTO(card);
                var cm = GetCommentFromDTO(comment);
                await repository.CardManager.RemoveCommentFromCardAsync(c, cm);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveLabelColorFromCard(CardDTO card, LabelColorDTO labelColor)
        {
            try
            {
                var c = GetCardFromDTO(card);
                var lc = GetLabelColorFromDTO(labelColor);
                await repository.CardManager.RemoveLabelColorFromCardAsync(c, lc);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveUserFromBoard(BoardDTO board, UserDTO user)
        {
            try
            {
                var b = GetBoardFromDTO(board);
                var u = GetUserFromDTO(user);
                await repository.BoardInteraction.RemoveUserFromBoardAsync(b, u);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoveUserFromCard(CardDTO card, UserDTO user)
        {
            try
            {
                var c = GetCardFromDTO(card);
                var u = GetUserFromDTO(user);
                await repository.CardManager.RemoveUserFromCardAsync(c, u);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RenameBoard(BoardDTO board, string newName)
        {
            try
            {
                var b = GetBoardFromDTO(board);
                await repository.BoardInteraction.RenameBoardAsync(b, newName);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RenameCardList(CardListDTO cardList, string newName)
        {
            try
            {
                var cl = GetCardListFromDTO(cardList);
                await repository.CardListInteraction.RenameCardListAsync(cl, newName);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task CommitChangesAsync()
        {
            await repository.CommitChangesAsync();
        }
        private async Task SendCallback()
        {
            var boards = await repository.BoardManager.GetEntitiesAsync();
            var boardDTOs = MapperHelper.BoardMapper.Map<IEnumerable<Board>, IEnumerable<BoardDTO>>(boards);
            serviceCallback.RefreshBoards(boardDTOs);
        }
        private async Task CommitAndSendCallbackAsync()
        {
            await CommitChangesAsync();
            await SendCallback();
        }
        private Board GetBoardFromDTO(BoardDTO boardDTO)
        {
            return MapperHelper.BoardMapper.Map<BoardDTO, Board>(boardDTO);
        }
        private CardList GetCardListFromDTO(CardListDTO cardListDTO)
        {
            return MapperHelper.CardListMapper.Map<CardListDTO, CardList>(cardListDTO);
        }
        private Card GetCardFromDTO(CardDTO cardDTO)
        {
            return MapperHelper.CardMapper.Map<CardDTO, Card>(cardDTO);
        }
        private Comment GetCommentFromDTO(CommentDTO commentDTO)
        {
            return MapperHelper.CommentMapper.Map<CommentDTO, Comment>(commentDTO);
        }
        private LabelColor GetLabelColorFromDTO(LabelColorDTO labelColorDTO)
        {
            return MapperHelper.LabelColorMapper.Map<LabelColorDTO, LabelColor>(labelColorDTO);
        }
        private User GetUserFromDTO(UserDTO userDTO)
        {
            return MapperHelper.UserMapper.Map<UserDTO, User>(userDTO);
        }
    }
}

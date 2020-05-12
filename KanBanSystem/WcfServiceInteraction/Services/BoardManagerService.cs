using KanbanSystemDAL.AdditionalClasses;
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
    public class BoardManagerService : IBoardManagerService
    {
        KanbanSystemContextRepository repository;
        IServiceCallback serviceCallback;
        public BoardManagerService()
        {
            repository = new KanbanSystemContextRepository();
            serviceCallback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
        }
        public async void AddBoardAsync(BoardDTO board)
        {
            try
            {
                var b = MapperBroker.GetBoardFromDTO(board);
                await repository.BoardManager.AddEntityAsync(b);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<BoardDTO>> GetBoardsAsync()
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

        public async void RemoveBoardAsync(BoardDTO board)
        {
            try
            {
                var b = MapperBroker.GetBoardFromDTO(board);
                await repository.BoardManager.RemoveEntityAsync(b);
                await CommitAndSendCallbackAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BoardDTO> UpdateBoardAsync(BoardDTO oldBoard, BoardDTO newBoard)
        {
            try
            {
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
        private async Task CommitChangesAsync()
        {
            await repository.CommitChangesAsync();
        }
        private async Task SendCallback()
        {
            var boards = await repository.BoardManager.GetEntitiesAsync();
            var boardDTOs = MapperBroker.GetBoardDTOsFromBoards(boards);
            serviceCallback.RefreshBoards(boardDTOs);
        }
        private async Task CommitAndSendCallbackAsync()
        {
            await CommitChangesAsync();
            await SendCallback();
        }
    }
}

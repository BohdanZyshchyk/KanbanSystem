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
                var b = MapperHelper.GetBoardFromDTO(board);
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
                var boardsDTO = MapperHelper.BoardMapper.Map<IEnumerable<Board>, IEnumerable<BoardDTO>>(boards);
                return boardsDTO;
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
                var b = MapperHelper.GetBoardFromDTO(board);
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
                var oldB = MapperHelper.GetBoardFromDTO(oldBoard);
                var newB = MapperHelper.GetBoardFromDTO(newBoard);
                oldB = await repository.BoardManager.UpdateEntityAsync(oldB, newB);
                await CommitAndSendCallbackAsync();
                return MapperHelper.BoardMapper.Map<Board, BoardDTO>(oldB);
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
    }
}

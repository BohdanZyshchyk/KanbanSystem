using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WcfServiceInteraction.CallbackInterfaces;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.ServiceInterfaces
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IBoardManagerService
    {
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
        Task<BoardDTO> UpdateBoard(BoardDTO oldBoard, BoardDTO newBoard);
        /// <summary>
        /// Add a new <paramref name="board"/> to database
        /// </summary>
        /// <param name="board"></param>
        [OperationContract]
        void AddBoard(BoardDTO board);
        /// <summary>
        /// Remove a specific <paramref name="board"/> from database
        /// </summary>
        /// <param name="board"></param>
        [OperationContract]
        void RemoveBoard(BoardDTO board);
    }
}

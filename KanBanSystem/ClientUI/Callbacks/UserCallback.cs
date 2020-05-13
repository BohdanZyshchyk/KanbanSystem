using ClientUI.KrabServices;
using System.Collections.Generic;

namespace ClientUI.Callbacks
{
    public class UserCallback : IKanbanSystemServiceCallback
    {
        public string Message { get; set; }
        public IEnumerable<BoardDTO> BoardDTOs { get; private set; }
        public UserCallback()
        {
        }
        public void InformAboutRegistration(string message)
        {
            Message = message;
        }

        public void RefreshBoards(BoardDTO[] boards)
        {
            BoardDTOs = boards;
        }
    }
}

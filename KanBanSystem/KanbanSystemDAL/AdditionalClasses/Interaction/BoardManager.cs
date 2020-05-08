using KanbanSystemDAL.Model;

namespace KanbanSystemDAL.AdditionalClasses.Interaction
{
    public class BoardManager : ManagerBase<Board>
    {
        public BoardManager(KanbanSystemContext context) : base(context)
        {
        }
    }
}

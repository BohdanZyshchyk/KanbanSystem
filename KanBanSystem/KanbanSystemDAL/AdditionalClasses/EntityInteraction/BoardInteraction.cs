using KanbanSystemDAL.Model;

namespace KanbanSystemDAL.AdditionalClasses.EntityInteraction
{
    public class BoardInteraction : EntityInteractionBase<Board>
    {
        public BoardInteraction(KanbanSystemContext _context) : base(_context)
        {

        }
    }
}

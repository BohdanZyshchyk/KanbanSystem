using KanbanSystemDAL.Model;

namespace KanbanSystemDAL.AdditionalClasses.EntityInteraction
{
    public class CommentInteraction : EntityInteractionBase<Comment>
    {
        public CommentInteraction(KanbanSystemContext _context) : base(_context)
        {

        }
    }
}

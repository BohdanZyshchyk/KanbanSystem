using KanbanSystemDAL.Model;

namespace KanbanSystemDAL.AdditionalClasses.EntityInteraction
{
    public class UserInteraction : EntityInteractionBase<User>
    {
        public UserInteraction(KanbanSystemContext _context) : base(_context)
        {
        }
    }
}

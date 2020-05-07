using KanbanSystemDAL.Model;

namespace KanbanSystemDAL.AdditionalClasses.EntityInteraction
{
    public class CardInteraction : EntityInteractionBase<Card>
    {
        public CardInteraction(KanbanSystemContext _context) : base(_context)
        {

        }
    }
}

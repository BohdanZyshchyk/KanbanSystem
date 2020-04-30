using KanbanSystemDAL.Model;

namespace KanbanSystemDAL.AdditionalClasses
{
    public class KanbanSystemContextRepository
    {
        KanbanSystemContext context;
        public KanbanSystemContext KanbanSystemContext
        {
            get
            {
                return context ?? new KanbanSystemContext();
            }
        }
    }
}

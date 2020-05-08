using KanbanSystemDAL.Model;

namespace KanbanSystemDAL.AdditionalClasses.Helpers
{
    /// <summary>
    /// A static class to get database context
    /// </summary>
        
    public static class ContextHelper
    {
        private static KanbanSystemContext context;
        /// <summary>
        /// Get a singleton context
        /// </summary>
        public static KanbanSystemContext KanbanSystemContext
        {
            get
            {
                if (context == null)
                {
                    context = new KanbanSystemContext();
                }
                return context;
            }
        }
    }
}

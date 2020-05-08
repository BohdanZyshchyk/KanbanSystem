using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.AdditionalClasses.Interaction;
using KanbanSystemDAL.Model;
using System;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses
{
    public class KanbanSystemContextRepository
    {
        KanbanSystemContext context;
        BoardInteraction boardInteraction;
        BoardManager boardManager;
        CardListInteraction cardListInteraction;
        CardManager cardManager;
        UserManager userManager;
        public KanbanSystemContextRepository()
        {
            context = ContextHelper.KanbanSystemContext;
            boardInteraction = new BoardInteraction(context);
            boardManager = new BoardManager(context);
            cardListInteraction = new CardListInteraction(context);
            cardManager = new CardManager(context);
            userManager = new UserManager(context);
        }
        /// <summary>
        /// Manages users, card lists and name of a specific board
        /// </summary>
        public BoardInteraction BoardInteraction { get => boardInteraction; }
        /// <summary>
        /// Add, Remove, Update or Get all boards from database
        /// </summary>
        public BoardManager BoardManager { get => boardManager; }
        /// <summary>
        /// Manage Add, Remove or Rename of a specific Card List
        /// </summary>
        public CardListInteraction CardListInteraction { get => cardListInteraction; }
        /// <summary>
        /// Add/Remove: User, Label Color, Comment of a specific Card;
        /// Change Name/Due Date of a specific Card
        /// </summary>
        public CardManager CardManager { get => cardManager; }
        /// <summary>
        /// Manage User Registration and Login
        /// </summary>
        public UserManager UserManager { get => userManager; }
        /// <summary>
        /// Commit any changes in database
        /// </summary>
        /// <returns></returns>
        public async Task CommitChangesAsync()
        {
            try
            {
                var result = await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

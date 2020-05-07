using KanbanSystemDAL.AdditionalClasses.EntityInteraction;
using KanbanSystemDAL.AdditionalClasses.Interfaces;
using KanbanSystemDAL.Model;
using System;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses
{
    public class KanbanSystemContextRepository
    {
        KanbanSystemContext context;
        BoardInteraction boardInteraction;
        CardListInteraction cardListInteraction;
        CardInteraction cardInteraction;
        CardActivityInteraction cardActivityInteraction;
        CommentInteraction commentInteraction;
        LabelColorInteraction labelColorInteraction;
        LoginDataInteraction loginDataInteraction;
        UserInteraction userInteraction;
        public KanbanSystemContextRepository()
        {
            
        }
        public KanbanSystemContext KanbanSystemContext { get { return context ?? new KanbanSystemContext(); } }
        public BoardInteraction BoardInteraction { get { return boardInteraction ?? new BoardInteraction(KanbanSystemContext); } }
        public CardListInteraction CardListInteraction { get { return cardListInteraction ?? new CardListInteraction(KanbanSystemContext); } }
        public CardInteraction CardInteraction { get { return cardInteraction ?? new CardInteraction(KanbanSystemContext); } }
        public CardActivityInteraction CardActivityInteraction { get { return cardActivityInteraction ?? new CardActivityInteraction(KanbanSystemContext); } }
        public CommentInteraction CommentInteraction { get { return commentInteraction ?? new CommentInteraction(KanbanSystemContext); } }
        public LabelColorInteraction LabelColorInteraction { get { return labelColorInteraction ?? new LabelColorInteraction(KanbanSystemContext); } }
        public LoginDataInteraction LoginDataInteraction { get { return loginDataInteraction ?? new LoginDataInteraction(KanbanSystemContext); } }
        public UserInteraction UserInteraction { get { return userInteraction ?? new UserInteraction(KanbanSystemContext); } }
        public async Task<bool> CommitChangesAsync()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var result = await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
    }
}

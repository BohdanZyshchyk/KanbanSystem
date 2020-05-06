using System;

namespace KanbanSystemDAL.Model
{
    public class CardActivity
    {
        public int CardActivityId { get; set; }
        public string CardActivityAction { get; set; }
        public virtual User User { get; set; }
        public virtual Card Card { get; set; }
        public DateTime Date { get; set; }
    }
}

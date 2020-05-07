using System;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class CardActivity : IComparable<CardActivity>
    {
        public int CardActivityId { get; set; }
        public string CardActivityAction { get; set; }
        public virtual User User { get; set; }
        public virtual Card Card { get; set; }
        public DateTime Date { get; set; }

        public int CompareTo(CardActivity other)
        {
            return this.CardActivityAction.CompareTo(other.CardActivityAction);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class Card : IComparable<Card>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CardName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<LabelColor> LabelColors { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual CardList CardList { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CardActivity> CardActivities { get; set; }
        public Card()
        {
            LabelColors = new HashSet<LabelColor>();
            Users = new HashSet<User>();
            Comments = new HashSet<Comment>();
            CardActivities = new HashSet<CardActivity>();
        }
        public int CompareTo(Card other)
        {
            var res1 = this.CardName.CompareTo(other.CardName);
            var res2 = this.Description.CompareTo(other.Description);
            return res1.Equals(0) && res2.Equals(0) ? 0 : -1;
        }
    }
}

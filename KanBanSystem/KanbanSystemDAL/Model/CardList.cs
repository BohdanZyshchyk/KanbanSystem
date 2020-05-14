using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class CardList : IComparable<CardList>
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual Board Board { get; set; }
        public virtual User Creator { get; set; }
        public CardList()
        {
            Cards = new HashSet<Card>();
        }

        public int CompareTo(CardList other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}

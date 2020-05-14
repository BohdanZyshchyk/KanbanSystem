using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class LabelColor : IComparable<LabelColor>
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Color { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public LabelColor()
        {
            Cards = new HashSet<Card>();
        }

        public int CompareTo(LabelColor other)
        {
            return this.Color.CompareTo(other.Color);
        }
    }
}

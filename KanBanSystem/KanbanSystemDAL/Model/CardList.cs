using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class CardList
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual Board Board { get; set; }
        public virtual User Creator { get; set; }
        public CardList()
        {
            Cards = new HashSet<Card>();
        }
    }
}

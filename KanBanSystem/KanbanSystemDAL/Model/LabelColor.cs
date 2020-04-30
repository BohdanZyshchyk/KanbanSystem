using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanSystemDAL.Model
{
    [Table("LabelColors")]
    [Serializable]
    public class LabelColor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Color { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public LabelColor()
        {
            Cards = new HashSet<Card>();
        }
    }
}

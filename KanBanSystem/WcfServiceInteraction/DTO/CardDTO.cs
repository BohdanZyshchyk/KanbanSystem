using System;
using System.Collections.Generic;

namespace WcfServiceInteraction.DTO
{
    public class CardDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CardName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<LabelColorDTO> LabelColors { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
        public virtual CardListDTO CardList { get; set; }
        public virtual ICollection<CommentDTO> Comments { get; set; }
        public virtual ICollection<CardActivityDTO> CardActivities { get; set; }
    }
}

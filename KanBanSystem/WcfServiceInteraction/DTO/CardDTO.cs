using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfServiceInteraction.DTO
{
    [DataContract]
    public class CardDTO
    {
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public string CardName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public virtual ICollection<LabelColorDTO> LabelColors { get; set; }
        [DataMember]
        public virtual ICollection<UserDTO> Users { get; set; }
        [DataMember]
        public virtual CardListDTO CardList { get; set; }
        [DataMember]
        public virtual ICollection<CommentDTO> Comments { get; set; }
        [DataMember]
        public virtual ICollection<CardActivityDTO> CardActivities { get; set; }
        public CardDTO()
        {
            LabelColors = LabelColors ?? new HashSet<LabelColorDTO>();
            Users = Users ?? new HashSet<UserDTO>();
            Comments = Comments ?? new HashSet<CommentDTO>();
            CardActivities = CardActivities ?? new HashSet<CardActivityDTO>();
        }
    }
}

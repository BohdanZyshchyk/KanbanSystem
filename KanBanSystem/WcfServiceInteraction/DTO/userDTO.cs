using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfServiceInteraction.DTO
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual ICollection<CardDTO> Cards { get; set; }
        [DataMember]
        public virtual ICollection<CommentDTO> UserComments { get; set; }
        [DataMember]
        public virtual LoginDataDTO LoginData { get; set; }
        [DataMember]
        public virtual ICollection<CardListDTO> CreatedCardLists { get; set; }
        [DataMember]
        public virtual ICollection<CardActivityDTO> CardActivities { get; set; }
        [DataMember]
        public virtual ICollection<BoardDTO> Boards { get; set; }
    }
}

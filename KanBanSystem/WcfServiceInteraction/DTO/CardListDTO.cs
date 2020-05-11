using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfServiceInteraction.DTO
{
    [DataContract]
    public class CardListDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual ICollection<CardDTO> Cards { get; set; }
        [DataMember]
        public virtual BoardDTO Board { get; set; }
        [DataMember]
        public virtual UserDTO Creator { get; set; }
    }
}

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfServiceInteraction.DTO
{
    [DataContract]
    public class BoardDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual ICollection<CardListDTO> CardLists { get; set; }
        [DataMember]
        public virtual ICollection<UserDTO> Users { get; set; }
        public BoardDTO()
        {
            CardLists = CardLists ?? new HashSet<CardListDTO>();
            Users = Users ?? new HashSet<UserDTO>();
        }
    }
}

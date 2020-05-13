using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfServiceInteraction.DTO
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public virtual ICollection<CardDTO> Cards { get; set; }
        [DataMember]
        public virtual ICollection<CommentDTO> UserComments { get; set; }
        [DataMember]
        public virtual ICollection<CardListDTO> CreatedCardLists { get; set; }
        [DataMember]
        public virtual ICollection<CardActivityDTO> CardActivities { get; set; }
        [DataMember]
        public virtual ICollection<BoardDTO> Boards { get; set; }
        public UserDTO()
        {
            Cards = Cards ?? new HashSet<CardDTO>();
            UserComments = UserComments ?? new HashSet<CommentDTO>();
            CreatedCardLists = CreatedCardLists ?? new HashSet<CardListDTO>();
            CardActivities = CardActivities ?? new HashSet<CardActivityDTO>();
            Boards = Boards ?? new HashSet<BoardDTO>();
        }
    }
}

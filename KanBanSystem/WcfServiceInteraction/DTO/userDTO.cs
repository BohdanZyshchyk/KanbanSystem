using System.Collections.Generic;

namespace WcfServiceInteraction.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public virtual ICollection<CardDTO> Cards { get; set; }
        public virtual ICollection<CommentDTO> UserComments { get; set; }
        public virtual LoginDataDTO LoginData { get; set; }
        public virtual ICollection<CardListDTO> CreatedCardLists { get; set; }
        public virtual ICollection<CardActivityDTO> CardActivities { get; set; }
        public virtual ICollection<BoardDTO> Boards { get; set; }
    }
}

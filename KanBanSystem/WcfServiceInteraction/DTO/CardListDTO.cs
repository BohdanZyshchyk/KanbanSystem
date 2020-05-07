using System.Collections.Generic;

namespace WcfServiceInteraction.DTO
{
    public class CardListDTO
    {
        public string Name { get; set; }
        public virtual ICollection<CardDTO> Cards { get; set; }
        public virtual BoardDTO Board { get; set; }
        public virtual UserDTO Creator { get; set; }
    }
}

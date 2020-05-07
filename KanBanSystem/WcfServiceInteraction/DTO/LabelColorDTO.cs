using System.Collections.Generic;

namespace WcfServiceInteraction.DTO
{
    public class LabelColorDTO
    {
        public string Color { get; set; }
        public virtual ICollection<CardDTO> Cards { get; set; }
    }
}

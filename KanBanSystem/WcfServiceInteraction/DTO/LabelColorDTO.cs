using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfServiceInteraction.DTO
{
    [DataContract]
    public class LabelColorDTO
    {
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public virtual ICollection<CardDTO> Cards { get; set; }
        public LabelColorDTO()
        {
            Cards = Cards ?? new HashSet<CardDTO>();
        }
    }
}

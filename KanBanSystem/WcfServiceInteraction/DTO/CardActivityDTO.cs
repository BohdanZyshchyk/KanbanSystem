using System;
using System.Runtime.Serialization;

namespace WcfServiceInteraction.DTO
{
    [DataContract]
    public class CardActivityDTO
    {
        [DataMember]
        public string CardActivityAction { get; set; }
        [DataMember]
        public virtual UserDTO User { get; set; }
        [DataMember]
        public virtual CardDTO Card { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
    }
}

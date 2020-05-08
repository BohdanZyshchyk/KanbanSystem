using System.Runtime.Serialization;

namespace WcfServiceInteraction.DTO
{
    [DataContract]
    public class CommentDTO
    {
        [DataMember]
        public string CommentContent { get; set; }
        [DataMember]
        public virtual UserDTO CommentAuthor { get; set; }
        [DataMember]
        public virtual CardDTO Card { get; set; }
    }
}

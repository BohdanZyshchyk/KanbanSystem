using System.Runtime.Serialization;

namespace WcfServiceInteraction.DTO
{
    [DataContract]
    public class LoginDataDTO
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public virtual UserDTO User { get; set; }
    }
}

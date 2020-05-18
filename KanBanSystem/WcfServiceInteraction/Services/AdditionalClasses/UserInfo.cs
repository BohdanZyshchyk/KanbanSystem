using System.Runtime.Serialization;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.Services.AdditionalClasses
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public UserDTO User { get; set; }
        [DataMember]
        public string Token { get; set; }
    }
}

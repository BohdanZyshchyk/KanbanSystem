namespace WcfServiceInteraction.DTO
{
    public class LoginDataDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual UserDTO User { get; set; }
    }
}

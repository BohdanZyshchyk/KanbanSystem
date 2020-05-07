namespace WcfServiceInteraction.DTO
{
    public class CommentDTO
    {
        public string CommentContent { get; set; }
        public virtual UserDTO CommentAuthor { get; set; }
        public virtual CardDTO Card { get; set; }
    }
}

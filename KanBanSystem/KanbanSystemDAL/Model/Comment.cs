using System;
using System.ComponentModel.DataAnnotations;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class Comment : IComparable<Comment>
    {
        public int Id { get; set; }
        [StringLength(500)]
        public string CommentContent { get; set; }
        public virtual User CommentAuthor { get; set; }
        public virtual Card Card { get; set; }

        public int CompareTo(Comment other)
        {
            var res1 = this.CommentContent.CompareTo(other.CommentContent);
            var res2 = this.CommentAuthor.CompareTo(other.CommentAuthor);
            return res1.Equals(0) && res2.Equals(0) ? 0 : -1;
        }
    }
}

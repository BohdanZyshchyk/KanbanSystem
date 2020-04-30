using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanSystemDAL.Model
{
    [Table("Comments")]
    [Serializable]
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string CommentContent { get; set; }
        public virtual User CommentAuthor { get; set; }
        public virtual Card Card { get; set; }
    }
}

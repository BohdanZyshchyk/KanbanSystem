using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanSystemDAL.Model
{
    [Table("Users")]
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Comment> UserComments { get; set; }
        public virtual LoginData LoginData { get; set; }
        public virtual ICollection<CardList> CreatedCardLists { get; set; }
        public virtual ICollection<CardActivity> CardActivities { get; set; }
        public User()
        {
            Cards = new HashSet<Card>();
            UserComments = new HashSet<Comment>();
            CreatedCardLists = new HashSet<CardList>();
            CardActivities = new HashSet<CardActivity>();
        }
    }
}

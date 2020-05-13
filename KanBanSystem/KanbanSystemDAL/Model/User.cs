using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class User : IComparable<User>
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Comment> UserComments { get; set; }
        public virtual ICollection<CardList> CreatedCardLists { get; set; }
        public virtual ICollection<CardActivity> CardActivities { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
        public User()
        {
            Cards = new HashSet<Card>();
            UserComments = new HashSet<Comment>();
            CreatedCardLists = new HashSet<CardList>();
            CardActivities = new HashSet<CardActivity>();
            Boards = new HashSet<Board>();
        }

        public int CompareTo(User other)
        {
            //var res1 = this.UserName.CompareTo(other.UserName);
            var res2 = this.Email.CompareTo(other.Email);
            var res3 = this.Password.CompareTo(other.Password);
            return /*res1.Equals(0) && */res2.Equals(0) && res3.Equals(0) ? 0 : -1;
        }
    }
}

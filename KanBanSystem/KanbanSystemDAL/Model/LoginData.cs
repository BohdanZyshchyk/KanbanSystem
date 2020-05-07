using System;
using System.ComponentModel.DataAnnotations;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class LoginData : IComparable<LoginData>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        public virtual User User { get; set; }

        public int CompareTo(LoginData other)
        {
            var res1 = this.Email.CompareTo(other.Email);
            var res2 = this.Password.CompareTo(other.Password);
            return res1.Equals(0) && res2.Equals(0) ? 0 : -1;
        }
    }
}

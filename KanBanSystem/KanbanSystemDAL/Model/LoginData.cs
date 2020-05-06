using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class LoginData
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        public virtual User User { get; set; }
    }
}

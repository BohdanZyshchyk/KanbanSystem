using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanSystemDAL.Model
{
    public class Board
    {
        public int BoardId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CardList> CardLists { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Board()
        {
            CardLists = new HashSet<CardList>();
            Users = new HashSet<User>();
        }
    }
}

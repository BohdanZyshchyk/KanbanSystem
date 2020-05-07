using System;
using System.Collections.Generic;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class Board : IComparable<Board>
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
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var b = (Board)obj;
                return this.Name.Equals(b.Name);
            }
        }
        public bool Equals(Board board)
        {
            return this.Equals(board as object);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Board other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}

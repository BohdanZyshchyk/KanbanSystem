﻿using System;
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

        public int CompareTo(Board other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}

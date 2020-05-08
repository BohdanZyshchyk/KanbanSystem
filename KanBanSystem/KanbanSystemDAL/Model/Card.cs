﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KanbanSystemDAL.Model
{
    [Serializable]
    public class Card : IComparable<Card>
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string CardName { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<LabelColor> LabelColors { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual CardList CardList { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CardActivity> CardActivities { get; set; }
        public Card()
        {
            LabelColors = new HashSet<LabelColor>();
            Users = new HashSet<User>();
            Comments = new HashSet<Comment>();
            CardActivities = new HashSet<CardActivity>();
        }
        public int CompareTo(Card other)
        {
            return this.Description.CompareTo(other.Description);
        }
    }
}

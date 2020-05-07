using System;

namespace WcfServiceInteraction.DTO
{
    public class CardActivityDTO
    {
        public string CardActivityAction { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual CardDTO Card { get; set; }
        public DateTime Date { get; set; }
    }
}

using AutoMapper;
using KanbanSystemDAL.Model;
using System.Collections.Generic;
using System.ServiceModel.Security.Tokens;

namespace WcfServiceInteraction.DTO
{
    public class BoardDTO
    {
        public string Name { get; set; }
        public virtual ICollection<CardListDTO> CardLists { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
    }
}

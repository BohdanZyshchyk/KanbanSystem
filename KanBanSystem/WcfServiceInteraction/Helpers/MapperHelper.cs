using AutoMapper;
using KanbanSystemDAL.Model;
using System;
using System.Security.Cryptography;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.Helpers
{
    public class MapperHelper
    {
        public IMapper BoardMapper { get; private set; }
        public IMapper CardActivityMapper { get; private set; }
        public IMapper CardMapper { get; private set; }
        public IMapper CardListMapper { get; private set; }
        public IMapper CommentMapper { get; private set; }
        public IMapper LabelColorMapper { get; private set; }
        public IMapper LoginDataMapper { get; private set; }
        public IMapper UserMapper { get; private set; }
        public MapperHelper()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            BoardMapper = GetBoardMapper();
            CardMapper = GetCardMapper();
            CardActivityMapper = GetCardActivityMapper();
            CardListMapper = GetCardListMapper();
            CommentMapper = GetCommentMapper();
            LabelColorMapper = GetLabelColorMapper();
            LoginDataMapper = GetLoginDataMapper();
            UserMapper = GetUserMapper();
        }

        private IMapper GetBoardMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Board, BoardDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CardLists, opt => opt.MapFrom(src => src.CardLists))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));

                x.CreateMap<BoardDTO, Board>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CardLists, opt => opt.MapFrom(src => src.CardLists))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
            });
            return config.CreateMapper();
        }
        private IMapper GetCardMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Card, CardDTO>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.CardName, opt => opt.MapFrom(src => src.CardName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.LabelColors, opt => opt.MapFrom(src => src.LabelColors))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.CardList, opt => opt.MapFrom(src => src.CardList))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.CardActivities, opt => opt.MapFrom(src => src.CardActivities));

                x.CreateMap<CardDTO, Card>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.CardName, opt => opt.MapFrom(src => src.CardName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.LabelColors, opt => opt.MapFrom(src => src.LabelColors))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.CardList, opt => opt.MapFrom(src => src.CardList))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.CardActivities, opt => opt.MapFrom(src => src.CardActivities));
            });
            return config.CreateMapper();
        }
        private IMapper GetCardActivityMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<CardActivity, CardActivityDTO>()
                .ForMember(dest => dest.CardActivityAction, opt => opt.MapFrom(src => src.CardActivityAction))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Card, opt => opt.MapFrom(src => src.Card))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

                x.CreateMap<CardActivityDTO, CardActivity>()
                .ForMember(dest => dest.CardActivityAction, opt => opt.MapFrom(src => src.CardActivityAction))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Card, opt => opt.MapFrom(src => src.Card))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
            });
            return config.CreateMapper();
        }
        private IMapper GetCardListMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<CardList, CardListDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.Cards))
                .ForMember(dest => dest.Board, opt => opt.MapFrom(src => src.Board))
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator));

                x.CreateMap<CardListDTO, CardList>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.Cards))
                .ForMember(dest => dest.Board, opt => opt.MapFrom(src => src.Board))
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator));
            });
            return config.CreateMapper();
        }
        private IMapper GetCommentMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.CommentContent, opt => opt.MapFrom(src => src.CommentContent))
                .ForMember(dest => dest.CommentAuthor, opt => opt.MapFrom(src => src.CommentAuthor))
                .ForMember(dest => dest.Card, opt => opt.MapFrom(src => src.Card));

                x.CreateMap<CommentDTO, Comment>()
                .ForMember(dest => dest.CommentContent, opt => opt.MapFrom(src => src.CommentContent))
                .ForMember(dest => dest.CommentAuthor, opt => opt.MapFrom(src => src.CommentAuthor))
                .ForMember(dest => dest.Card, opt => opt.MapFrom(src => src.Card));
            });
            return config.CreateMapper();
        }
        private IMapper GetLabelColorMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<LabelColor, LabelColorDTO>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.Cards));

                x.CreateMap<LabelColorDTO, LabelColor>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.Cards));
            });
            return config.CreateMapper();
        }
        private IMapper GetLoginDataMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<LoginData, LoginDataDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

                x.CreateMap<LoginDataDTO, LoginData>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
            });
            return config.CreateMapper();
        }
        private IMapper GetUserMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.Cards))
                .ForMember(dest => dest.UserComments, opt => opt.MapFrom(src => src.UserComments))
                .ForMember(dest => dest.LoginData, opt => opt.MapFrom(src => src.LoginData))
                .ForMember(dest => dest.CreatedCardLists, opt => opt.MapFrom(src => src.CreatedCardLists))
                .ForMember(dest => dest.CardActivities, opt => opt.MapFrom(src => src.CardActivities))
                .ForMember(dest => dest.Boards, opt => opt.MapFrom(src => src.Boards));

                x.CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.Cards))
                .ForMember(dest => dest.UserComments, opt => opt.MapFrom(src => src.UserComments))
                .ForMember(dest => dest.LoginData, opt => opt.MapFrom(src => src.LoginData))
                .ForMember(dest => dest.CreatedCardLists, opt => opt.MapFrom(src => src.CreatedCardLists))
                .ForMember(dest => dest.CardActivities, opt => opt.MapFrom(src => src.CardActivities))
                .ForMember(dest => dest.Boards, opt => opt.MapFrom(src => src.Boards));
            });
            return config.CreateMapper();
        }
    }
}

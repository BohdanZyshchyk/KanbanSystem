using AutoMapper;
using KanbanSystemDAL.Model;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.Helpers
{
    public static class MapperHelper
    {
        private static IMapper mapper;
        static MapperHelper()
        {
            mapper = GetMapper();
        }
        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                #region Board map
                x.CreateMap<Board, BoardDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CardLists, opt => opt.MapFrom(src => src.CardLists))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));

                x.CreateMap<BoardDTO, Board>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CardLists, opt => opt.MapFrom(src => src.CardLists))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
                #endregion

                #region Card map
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
                #endregion

                #region Card activity map
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
                #endregion

                #region Card list map
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
                #endregion

                #region Comment map
                x.CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.CommentContent, opt => opt.MapFrom(src => src.CommentContent))
                .ForMember(dest => dest.CommentAuthor, opt => opt.MapFrom(src => src.CommentAuthor))
                .ForMember(dest => dest.Card, opt => opt.MapFrom(src => src.Card));

                x.CreateMap<CommentDTO, Comment>()
                .ForMember(dest => dest.CommentContent, opt => opt.MapFrom(src => src.CommentContent))
                .ForMember(dest => dest.CommentAuthor, opt => opt.MapFrom(src => src.CommentAuthor))
                .ForMember(dest => dest.Card, opt => opt.MapFrom(src => src.Card));
                #endregion

                #region Label color map
                x.CreateMap<LabelColor, LabelColorDTO>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.Cards));

                x.CreateMap<LabelColorDTO, LabelColor>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.Cards));
                #endregion

                #region Login data map
                x.CreateMap<LoginData, LoginDataDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

                x.CreateMap<LoginDataDTO, LoginData>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
                #endregion

                #region User map
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
                #endregion
            });
            return config.CreateMapper();
        }
        /// <summary>
        /// <typeparamref name="TDTO"/> - type of DTO to map from. <typeparamref name="TEntity"/> - type of entity to map to. <paramref name="dto"/> - source
        /// </summary>
        /// <typeparam name="TDTO"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static TEntity GetEntityFromDTO<TDTO, TEntity>(TDTO dto)
            where TEntity : class
            where TDTO : class
        {
            return mapper.Map<TDTO, TEntity>(dto);
        }
        /// <summary>
        /// <typeparamref name="TEntity"/> - type of entity to map from.<typeparamref name="TDTO"/> - type of DTO to map to. <paramref name="entity"/> - source
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TDTO"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TDTO GetDTOFromEntity<TEntity, TDTO>(TEntity entity)
            where TEntity : class
            where TDTO : class
        {
            return mapper.Map<TEntity, TDTO>(entity);
        }
    }
}

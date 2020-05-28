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
                x.CreateMap<Board, BoardDTO>();

                x.CreateMap<BoardDTO, Board>();
                #endregion

                #region Card map
                x.CreateMap<Card, CardDTO>()
                .ForMember(dest => dest.CardList, opt => opt.Ignore());

                x.CreateMap<CardDTO, Card>()
                .ForMember(dest => dest.CardList, opt => opt.Ignore());
                #endregion

                #region Card activity map
                x.CreateMap<CardActivity, CardActivityDTO>();

                x.CreateMap<CardActivityDTO, CardActivity>();
                #endregion

                #region Card list map
                x.CreateMap<CardList, CardListDTO>()
                .ForMember(dest => dest.Board, opt => opt.Ignore());

                x.CreateMap<CardListDTO, CardList>()
                .ForMember(dest => dest.Board, opt => opt.Ignore());
                #endregion

                #region Comment map
                x.CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.Card, opt => opt.Ignore());

                x.CreateMap<CommentDTO, Comment>()
                .ForMember(dest => dest.Card, opt => opt.Ignore());
                #endregion

                #region Label color map
                x.CreateMap<LabelColor, LabelColorDTO>()
                .ForMember(dest => dest.Cards, opt => opt.Ignore());

                x.CreateMap<LabelColorDTO, LabelColor>()
                .ForMember(dest => dest.Cards, opt => opt.Ignore());
                #endregion

                #region User map
                x.CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Cards, opt => opt.Ignore())
                .ForMember(dest => dest.UserComments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedCardLists, opt => opt.Ignore())
                .ForMember(dest => dest.CardActivities, opt => opt.Ignore())
                .ForMember(dest => dest.Boards, opt => opt.Ignore());

                x.CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Cards, opt => opt.Ignore())
                .ForMember(dest => dest.UserComments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedCardLists, opt => opt.Ignore())
                .ForMember(dest => dest.CardActivities, opt => opt.Ignore())
                .ForMember(dest => dest.Boards, opt => opt.Ignore());
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

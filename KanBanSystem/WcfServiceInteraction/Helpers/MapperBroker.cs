using KanbanSystemDAL.Model;
using System.Collections.Generic;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.Helpers
{
    public static class MapperBroker
    {
        public static Board GetBoardFromDTO(BoardDTO boardDTO)
        {
            return MapperHelper.GetEntityFromDTO<BoardDTO, Board>(boardDTO);
        }
        public static BoardDTO GetBoardDTOFromEntity(Board board)
        {
            return MapperHelper.GetDTOFromEntity<Board, BoardDTO>(board);
        }
        public static CardActivity GetCardActivityFromDTO(CardActivityDTO cardActivityDTO)
        {
            return MapperHelper.GetEntityFromDTO<CardActivityDTO, CardActivity>(cardActivityDTO);
        }
        public static CardActivityDTO GetCardActivityDTOFromEntity(CardActivity cardActivity)
        {
            return MapperHelper.GetDTOFromEntity<CardActivity, CardActivityDTO>(cardActivity);
        }
        public static Card GetCardFromDTO(CardDTO cardDTO)
        {
            return MapperHelper.GetEntityFromDTO<CardDTO, Card>(cardDTO);
        }
        public static CardDTO GetCardDTOFromEntity(Card card)
        {
            return MapperHelper.GetDTOFromEntity<Card, CardDTO>(card);
        }
        public static CardList GetCardListFromDTO(CardListDTO cardListDTO)
        {
            return MapperHelper.GetEntityFromDTO<CardListDTO, CardList>(cardListDTO);
        }
        public static CardListDTO GetCardListDTOFromEntity(CardList cardList)
        {
            return MapperHelper.GetDTOFromEntity<CardList, CardListDTO>(cardList);
        }
        public static Comment GetCommentFromDTO(CommentDTO commentDTO)
        {
            return MapperHelper.GetEntityFromDTO<CommentDTO, Comment>(commentDTO);
        }
        public static CommentDTO GetCommentDTOFromEntity(Comment comment)
        {
            return MapperHelper.GetEntityFromDTO<Comment, CommentDTO>(comment);
        }
        public static LabelColor GetLabelColorFromDTO(LabelColorDTO labelColorDTO)
        {
            return MapperHelper.GetEntityFromDTO<LabelColorDTO, LabelColor>(labelColorDTO);
        }
        public static LabelColorDTO GetLabelColorDTOFromEntity(LabelColor labelColor)
        {
            return MapperHelper.GetEntityFromDTO<LabelColor, LabelColorDTO>(labelColor);
        }
        public static LoginData GetLoginDataFromDTO(LoginDataDTO loginDataDTO)
        {
            return MapperHelper.GetEntityFromDTO<LoginDataDTO, LoginData>(loginDataDTO);
        }
        public static LoginDataDTO GetLoginDataDTOFromEntity(LoginData loginData)
        {
            return MapperHelper.GetEntityFromDTO<LoginData, LoginDataDTO>(loginData);
        }
        public static User GetUserFromDTO(UserDTO userDTO)
        {
            return MapperHelper.GetEntityFromDTO<UserDTO, User>(userDTO);
        }
        public static UserDTO GetUserDTOFromEntity(User user)
        {
            return MapperHelper.GetEntityFromDTO<User, UserDTO>(user);
        }
        public static IEnumerable<BoardDTO> GetBoardDTOsFromBoards(IEnumerable<Board> boards)
        {
            return MapperHelper.GetEntityFromDTO<IEnumerable<Board>, IEnumerable<BoardDTO>>(boards);
        }
    }
}

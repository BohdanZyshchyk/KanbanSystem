using KanbanSystemDAL.AdditionalClasses;
using KanbanSystemDAL.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WcfServiceInteraction.DTO;
using WcfServiceInteraction.Helpers;
using WcfServiceInteraction.ServiceInterfaces;

namespace WcfServiceInteraction
{
    public class KanBanSystemService : IBoardService, ICardActivityService, ICardListService, ICardService, ICommentService, ILabelColorService, ILoginDataService, IUserService
    {
        KanbanSystemContextRepository contextRepository;
        MapperHelper mapperHelper;
        public KanBanSystemService()
        {
            contextRepository = new KanbanSystemContextRepository();
            mapperHelper = new MapperHelper();
        }
        #region ADDs
        public async Task<bool> AddEntityAsync(BoardDTO entity)
        {
            await contextRepository.BoardInteraction.AddEntityAsync(mapperHelper.BoardMapper.Map<BoardDTO, Board>(entity));
            var saved = await contextRepository.CommitChangesAsync();
            return true;
        }

        public async Task<bool> AddEntityAsync(CardActivityDTO entity)
        {
            await contextRepository.CardActivityInteraction.AddEntityAsync(mapperHelper.CardActivityMapper.Map<CardActivityDTO, CardActivity>(entity));
            var saved = await contextRepository.CommitChangesAsync();
            return true;
        }

        public async Task<bool> AddEntityAsync(CardListDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddEntityAsync(CardDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddEntityAsync(CommentDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddEntityAsync(LabelColorDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddEntityAsync(LoginDataDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddEntityAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GETs
        public async Task<IEnumerable<BoardDTO>> GetEntitiesAsync(BoardDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CardActivityDTO>> GetEntitiesAsync(CardActivityDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CardListDTO>> GetEntitiesAsync(CardListDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CardDTO>> GetEntitiesAsync(CardDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentDTO>> GetEntitiesAsync(CommentDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LabelColorDTO>> GetEntitiesAsync(LabelColorDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LoginDataDTO>> GetEntitiesAsync(LoginDataDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetEntitiesAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region REMOVEs
        public async Task<bool> RemoveEntityAsync(BoardDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveEntityAsync(CardActivityDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveEntityAsync(CardListDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveEntityAsync(CardDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveEntityAsync(CommentDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveEntityAsync(LabelColorDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveEntityAsync(LoginDataDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveEntityAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UPDATEs
        public async Task<bool> UpdateEntityAsync(BoardDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEntityAsync(CardActivityDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEntityAsync(CardListDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEntityAsync(CardDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEntityAsync(CommentDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEntityAsync(LabelColorDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEntityAsync(LoginDataDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEntityAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

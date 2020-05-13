using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.Model;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Interaction
{
    public class BoardInteraction
    {
        private KanbanSystemContext context;
        public BoardInteraction(KanbanSystemContext _context)
        {
            context = _context;
        }
        public async Task AddUserToBoardAsync(Board board, User user)
        {
            try
            {
                var foundBoard = await FindAndCheckNullabilityHelper<Board>.InDatabaseAsync(context.Boards, board, "Board was not found!", false);
                var foundUser = await FindAndCheckNullabilityHelper<User>.InDatabaseAsync(context.Users, user, "User does not exist in database!", false);
                foundUser = await FindAndCheckNullabilityHelper<User>.InCollectionAsync(foundBoard.Users, user, "User is already assigned to this board!", true);
                foundBoard.Users.Add(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task RemoveUserFromBoardAsync(Board board, User user)
        {
            try
            {
                var foundBoard = await FindAndCheckNullabilityHelper<Board>.InDatabaseAsync(context.Boards, board, "Board was not found!", false);
                var foundUser = await FindAndCheckNullabilityHelper<User>.InDatabaseAsync(context.Users, user, "User does not exist in database!", false);
                foundUser = await FindAndCheckNullabilityHelper<User>.InCollectionAsync(foundBoard.Users, user, "User is not assigned to this board!", false);
                foundBoard.Users.Remove(foundUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AddCardListToBoardAsync(Board board, CardList cardList)
        {
            try
            {
                var foundBoard = await FindAndCheckNullabilityHelper<Board>.InDatabaseAsync(context.Boards, board, "Board was not found!", false);
                var foundCardList = await FindAndCheckNullabilityHelper<CardList>.InCollectionAsync(foundBoard.CardLists, cardList, "Card list is already in this board!", true);
                cardList.Board = foundBoard;
                context.Set<CardList>().Add(cardList);
                //foundBoard.CardLists.Add(cardList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task RemoveCardListFromBoardAsync(Board board, CardList cardList)
        {
            try
            {
                var foundBoard = await FindAndCheckNullabilityHelper<Board>.InDatabaseAsync(context.Boards, board, "Board was not found!", false);
                var foundCardList = await FindAndCheckNullabilityHelper<CardList>.InCollectionAsync(foundBoard.CardLists, cardList, "Card list not found!", false);
                foundBoard.CardLists.Remove(foundCardList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task RenameBoardAsync(Board board, string newName)
        {
            try
            {
                var foundBoard = await FindAndCheckNullabilityHelper<Board>.InDatabaseAsync(context.Boards, board, "Board was not found!", false);
                if (foundBoard.Name.Equals(newName))
                {
                    throw new Exception("Names are equal!");
                }
                else
                {
                    context.Entry<Board>(foundBoard).State = EntityState.Detached;
                    foundBoard.Name = newName;
                    context.Entry<Board>(foundBoard).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

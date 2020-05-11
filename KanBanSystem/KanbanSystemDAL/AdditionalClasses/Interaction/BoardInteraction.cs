﻿using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.Model;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

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
                var foundBoard = await FindBoardASync(board);
                var foundUser = await FindHelper<User>.FindEntityAsync(foundBoard.Users, user);
                foundUser = CheckNullHelper<User>.CheckNullable(foundUser, "User is already assigned to this board!", true);
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
                var foundBoard = await FindBoardASync(board);
                var foundUser = await FindHelper<User>.FindEntityAsync(foundBoard.Users, user);
                foundUser = CheckNullHelper<User>.CheckNullable(foundUser, "User not found!", false);
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
                var foundBoard = await FindBoardASync(board);
                var foundCardList = await FindHelper<CardList>.FindEntityAsync(foundBoard.CardLists, cardList);
                foundCardList = CheckNullHelper<CardList>.CheckNullable(foundCardList, "Card list is already in this board!", true);
                foundBoard.CardLists.Add(cardList);
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
                var foundBoard = await FindBoardASync(board);
                var foundCardList = await FindHelper<CardList>.FindEntityAsync(foundBoard.CardLists, cardList);
                foundCardList = CheckNullHelper<CardList>.CheckNullable(foundCardList, "Card list not found!", false);
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
                var foundBoard = await FindBoardASync(board);
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
        private async Task<Board> FindBoardASync(Board board)
        {
            var foundBoard = await FindHelper<Board>.FindEntityAsync(context.Boards, board);
            return foundBoard ?? throw new Exception("Board not found!");
        }
    }
}
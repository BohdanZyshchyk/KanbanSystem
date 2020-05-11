using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.Model;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Interaction
{
    public class CardManager
    {
        private KanbanSystemContext context;
        public CardManager(KanbanSystemContext _context)
        {
            context = _context;
        }
        public async Task AddUserToCardAsync(Card card, User user)
        {
            try
            {
                var foundCard = await FindCardAsync(card);
                var foundUser = await FindHelper<User>.FindEntityAsync(foundCard.Users, user);
                foundUser = CheckNullHelper<User>.CheckNullable(foundUser, "User is already assigned to this card!", true);
                foundCard.Users.Add(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task RemoveUserFromCardAsync(Card card, User user)
        {
            try
            {
                var foundCard = await FindCardAsync(card);
                var foundUser = await FindHelper<User>.FindEntityAsync(foundCard.Users, user);
                foundUser = CheckNullHelper<User>.CheckNullable(foundUser, "User not found!", false);
                foundCard.Users.Remove(foundUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AddLabelColorToCardAsync(Card card, LabelColor labelColor)
        {
            try
            {
                var foundCard = await FindCardAsync(card);
                var foundLabeColor = await FindHelper<LabelColor>.FindEntityAsync(foundCard.LabelColors, labelColor);
                foundLabeColor = CheckNullHelper<LabelColor>.CheckNullable(foundLabeColor, "Such label color is already assigned to this card!", true);
                foundCard.LabelColors.Add(labelColor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task RemoveLabelColorFromCardAsync(Card card, LabelColor labelColor)
        {
            try
            {
                var foundCard = await FindCardAsync(card);
                var foundLabeColor = await FindHelper<LabelColor>.FindEntityAsync(foundCard.LabelColors, labelColor);
                foundLabeColor = CheckNullHelper<LabelColor>.CheckNullable(foundLabeColor, "Label color not found!", false);
                foundCard.LabelColors.Remove(foundLabeColor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AddCommentToCardAsync(Card card, Comment comment)
        {
            try
            {
                var foundCard = await FindCardAsync(card);
                var foundComment = await FindHelper<Comment>.FindEntityAsync(foundCard.Comments, comment);
                foundComment = CheckNullHelper<Comment>.CheckNullable(foundComment, "Comment is already assigned to a card!", true);
                foundCard.Comments.Add(comment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task RemoveCommentFromCardAsync(Card card, Comment comment)
        {
            try
            {
                var foundCard = await FindCardAsync(card);
                var foundComment = await FindHelper<Comment>.FindEntityAsync(foundCard.Comments, comment);
                foundComment = CheckNullHelper<Comment>.CheckNullable(foundComment, "Comment was not found!", false);
                foundCard.Comments.Remove(foundComment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task ChangeDueDateOfACardAsync(Card card, DateTime date)
        {
            try
            {
                var foundCard = await FindCardAsync(card);
                if (foundCard.DueDate.Equals(date))
                {
                    throw new Exception("Dates are the same!");
                }
                else
                {
                    context.Entry<Card>(foundCard).State = EntityState.Detached;
                    foundCard.DueDate = date;
                    context.Entry<Card>(foundCard).State = EntityState.Modified;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task ChangeNameOfACardAsync(Card card, string newName)
        {
            try
            {
                var foundCard = await FindCardAsync(card);
                if (foundCard.CardName.Equals(newName))
                {
                    throw new Exception("Names are the same!");
                }
                else
                {
                    context.Entry<Card>(foundCard).State = EntityState.Detached;
                    foundCard.CardName = newName;
                    context.Entry<Card>(foundCard).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<Card> FindCardAsync(Card card)
        {
            var foundCard = await FindHelper<Card>.FindEntityAsync(context.Cards, card);
            return foundCard ?? throw new Exception("Card not found!");
        }
    }
}

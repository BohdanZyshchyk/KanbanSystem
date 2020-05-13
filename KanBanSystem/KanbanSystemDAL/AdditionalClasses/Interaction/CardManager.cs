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
                var foundCard = await FindAndCheckNullabilityHelper<Card>.InDatabaseAsync(context.Cards, card, "Card not found!", false);
                var foundUser = await FindAndCheckNullabilityHelper<User>.InCollectionAsync(foundCard.Users, user, "User is already assigned to this card!", true);
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
                var foundCard = await FindAndCheckNullabilityHelper<Card>.InDatabaseAsync(context.Cards, card, "Card not found!", false);
                var foundUser = await FindAndCheckNullabilityHelper<User>.InCollectionAsync(foundCard.Users, user, "User was not found!", false);
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
                var foundCard = await FindAndCheckNullabilityHelper<Card>.InDatabaseAsync(context.Cards, card, "Card not found!", false);
                var foundLabeColor = await FindAndCheckNullabilityHelper<LabelColor>.InCollectionAsync(foundCard.LabelColors, labelColor, "Such label color is already assigned to this card!", true);
                labelColor.Cards.Add(foundCard);
                context.Set<LabelColor>().Add(labelColor);
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
                var foundCard = await FindAndCheckNullabilityHelper<Card>.InDatabaseAsync(context.Cards, card, "Card not found!", false);
                var foundLabeColor = await FindAndCheckNullabilityHelper<LabelColor>.InCollectionAsync(foundCard.LabelColors, labelColor, "Label color was not found!", false);
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
                var foundCard = await FindAndCheckNullabilityHelper<Card>.InDatabaseAsync(context.Cards, card, "Card not found!", false);
                var foundComment = await FindAndCheckNullabilityHelper<Comment>.InCollectionAsync(foundCard.Comments, comment, "Comment is already assigned to a card!", true);
                comment.Card = foundCard;
                context.Set<Comment>().Add(comment);
                //foundCard.Comments.Add(comment);
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
                var foundCard = await FindAndCheckNullabilityHelper<Card>.InDatabaseAsync(context.Cards, card, "Card not found!", false);
                var foundComment = await FindAndCheckNullabilityHelper<Comment>.InCollectionAsync(foundCard.Comments, comment, "Comment was not found!", false);
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
                var foundCard = await FindAndCheckNullabilityHelper<Card>.InDatabaseAsync(context.Cards, card, "Card not found!", false);
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
                var foundCard = await FindAndCheckNullabilityHelper<Card>.InDatabaseAsync(context.Cards, card, "Card not found!", false);
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
    }
}

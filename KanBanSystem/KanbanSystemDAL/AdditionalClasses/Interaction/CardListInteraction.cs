using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.Model;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Interaction
{
    public class CardListInteraction
    {
        KanbanSystemContext context;
        public CardListInteraction(KanbanSystemContext _context)
        {
            context = _context;
        }
        public async Task AddCardToCardListAsync(CardList cardList, Card card)
        {
            var foundCardList = await FindAndCheckNullabilityHelper<CardList>.InDatabaseAsync(context.CardLists, cardList, "Card list not found!", false);
            var foundCard = await FindAndCheckNullabilityHelper<Card>.InCollectionAsync(foundCardList.Cards, card, "Card is already in this card list!", true);
            foundCardList.Cards.Add(card);
        }
        public async Task RemoveCardFromCardListAsync(CardList cardList, Card card)
        {
            var foundCardList = await FindAndCheckNullabilityHelper<CardList>.InDatabaseAsync(context.CardLists, cardList, "Card list not found!", false);
            var foundCard = await FindAndCheckNullabilityHelper<Card>.InCollectionAsync(foundCardList.Cards, card, "Card not found!", false);
            foundCardList.Cards.Remove(foundCard);
        }
        public async Task RenameCardListAsync(CardList cardList, string newName)
        {
            var foundCardList = await FindAndCheckNullabilityHelper<CardList>.InDatabaseAsync(context.CardLists, cardList, "Card list not found!", false);
            if (foundCardList.Name.Equals(newName))
            {
                throw new Exception("Names are equal!");
            }
            else
            {
                context.Entry<CardList>(foundCardList).State = EntityState.Detached;
                foundCardList.Name = newName;
                context.Entry<CardList>(foundCardList).State = EntityState.Modified;
            }
        }
    }
}

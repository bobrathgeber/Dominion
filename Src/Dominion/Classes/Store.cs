using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Dominion.Classes;

namespace Dominion
{
    public class Store
    {
        public List<Card> stock;
        public List<int> stockAmount;
        public Player currentPlayer;
        public BuyCardAction bAction;
        public List<Label> Labels;

        public Player CurrentPlayer
        {
            set { currentPlayer = value; }
        }

        ////10 cards per action except gardens
        //private static string "cellar;
        //private static string "chapel;
        //private static string "moat;
        //private static string "chancellor;
        //private static string "village;
        //private static string "woodcutter;
        //private static string "wordshop;
        //private static string "bureaucrat;
        //private static string "feast;
        //private static string "gardens; //12
        //private static string "militia;
        //private static string "moneylender;
        //private static string "remodel;
        //private static string "smithy;
        //private static string "spy;
        //private static string "thief;
        //private static string "throneRoom;
        //private static string "councilRoom;
        //private static string "festival;
        //private static string "laboratory;
        //private static string "library;
        //private static string "market;
        //private static string "mine;
        //private static string "witch;
        //private static string "adventurer;

        //private static string "curse; //30 Curses
        //private static string "estate; //24
        //private static string "duchy; //12
        //private static string "province; //12

        //private static string "copper; //60
        //private static string "silver; //40
        //private static string "gold"; //30

        public Boolean checkEndGame()
        {
            //int exhaustedStocks=0;
            //for (int i = 0; i < stockAmount.Count; i++)
            //{
            //    if (stockAmount[i] < 1)
            //    {
            //        exhaustedStocks += 1;
            //    }
            //    if (stock[i].Name == "Province" && stockAmount[i] < 1)
            //    {
            //        return true;
            //    }
            //}
            //if (exhaustedStocks >= 3)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}\
            return false;
        }

        public void AddCard(Card card)
        {
            var existing_stack_top_card = stock.FirstOrDefault(x => x.Name == card.Name);

            if (existing_stack_top_card != null)
                card.position = existing_stack_top_card.position;
            else
            {
                var groups = stock.GroupBy(x => x.Name);
                var group_count = groups.Count();
                var stockCountLabel = new Label();
                
                card.Scale(card.Image.Width / 2, card.Image.Height / 2);

                if (group_count >= 8)
                    card.Location(40 + ((group_count - 8) * card.Image.Width / 2), 250);
                else
                {
                    card.Location(40 + (group_count * card.Image.Width / 2), 100);
                }
    
                stockCountLabel.Text = stock.Count(x => x.Name == card.Name).ToString();
                stockCountLabel.BoundingBox = (new Vector2(card.position.X+(card.position.Width/2 - stockCountLabel.GetSize().X / 2), card.position.Y+card.position.Height));
                ServiceLocator.GameEntities.Add(stockCountLabel);
                
            }

            stock.Add(card);
        }

        //public void UpdateLabels()
        //{
        //    foreach (var lbl in Labels)
        //    {
        //        lbl.Text = stock.Count(x => x.Name == sb.CardName).ToString();
        //    }
        //}
        
        public void buyCard(Player p, Card c)
        {
            for(int i = stock.Count-1; i>=0; i--)
            {
                if (stock[i].Name == c.Name && p.Buys > 0 && p.Coins >= c.Cost)
                {
                    p.addCardToDiscard(stock[i]);
                    stock.RemoveAt(i);
                    p.Buys -= 1;
                    p.Coins -= c.Cost;
                    return;                    
                }                
            }
        }

        public IEnumerable<IGrouping<string, Card>>CardGroups
        {
            get
            {
                return stock.GroupBy(x => x.Name);
            }
        }


        public List<Card> GetFirstCardInEachGroup()
        {
            var result = new List<Card>();

            foreach (var group in stock.GroupBy(x => new { x.Name }))
            {
                result.Add(group.First());
            }

            return result;
        }

        public List<string> GetUniqueCardTypes()
        {
            var result = new List<string>();

            foreach(var kvp in stock.ToDictionary(x => x.Name))
            {
                result.Add(kvp.Key);
            }

            return result;

        }

        public Store()
        {
            stock = new List<Card>();
            bAction = new BuyCardAction();
            //check game mode ***UPDATE LATER***
            if (true)
            {
                AddMany(() => new MoatCard(null), 10);
                AddMany(() => new VillageCard(null), 10);
                AddMany(() => new WoodcutterCard(null), 10);
                AddMany(() => new MilitiaCard(null), 10);
                AddMany(() => new SmithyCard(null), 10);
                AddMany(() => new MarketCard(null), 10);
                AddMany(() => new EstateCard(null), 10);
                AddMany(() => new EstateCard(null), 10);

                //stock.Add(c = new CellarCard(null));
                //stock.Add(c = new WorkshopCard(null));
                //stock.Add(c = new RemodelCard(null));
                //stock.Add(c = new MineCard(null));

                resetTreasureAndVP();
            }
        }

        private void resetTreasureAndVP()
        {
            AddMany(() => new EstateCard(null), 24);
            AddMany(() => new DuchyCard(null), 12);
            AddMany(() => new ProvinceCard(null), 12);
            AddMany(() => new CopperCard(null), 60);
            AddMany(() => new SilverCard(null), 40);
            AddMany(() => new GoldCard(null), 30);
        }

        private void AddMany(Func<Card> action, int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                AddCard(action.Invoke());
            }
        }
    }
}

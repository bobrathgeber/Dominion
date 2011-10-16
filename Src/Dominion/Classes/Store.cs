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
            int exhaustedStocks=0;
            for (int i = 0; i < stockAmount.Count; i++)
            {
                if (stockAmount[i] < 1)
                {
                    exhaustedStocks += 1;
                }
                if (stock[i].Name == "Province" && stockAmount[i] < 1)
                {
                    return true;
                }
            }
            if (exhaustedStocks >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void buyCard(Player p, Card c)
        {
            for(int i = stock.Count-1; i>=0; i--)
            {
                if (stock[i].Name == c.Name && stockAmount[i]>0 && p.Buys > 0 && p.Coins >= c.Cost)
                {
                    stockAmount[i] -= 1;
                    p.addCardToDiscard(c);
                    p.Buys -= 1;
                    p.Coins -= c.Cost;
                    return;                    
                }                
            }
        }

        public Store()
        {
            stock = new List<Card>();
            stockAmount = new List<int>();
            bAction = new BuyCardAction();
            Card c;
            //check game mode ***UPDATE LATER***
            if (true)
            {
                //stock.Add(c = new CellarCard(null));
                stock.Add(c = new MoatCard(null));
                stock.Add(c = new VillageCard(null));
                stock.Add(c = new WoodcutterCard(null));
                //stock.Add(c = new WorkshopCard(null));
                stock.Add(c = new MilitiaCard(null));
                //stock.Add(c = new RemodelCard(null));
                stock.Add(c = new SmithyCard(null));
                stock.Add(c = new MarketCard(null));
                //stock.Add(c = new MineCard(null));

                for(int i = 0; i<stock.Count; i++)
                {
                    stockAmount.Add(10);
                }
                resetTreasureAndVP();
            }
        }

        private void resetTreasureAndVP()
        {
            Card c;
            stock.Add(c = new EstateCard(null));
            stockAmount.Add(24);
            stock.Add(c = new DuchyCard(null));
            stockAmount.Add(12);
            stock.Add(c = new ProvinceCard(null));
            stockAmount.Add(12);

            stock.Add(c = new CopperCard(null));
            stockAmount.Add(60);
            stock.Add(c = new SilverCard(null));
            stockAmount.Add(40);
            stock.Add(c = new GoldCard(null));
            stockAmount.Add(30);
        }        
    }
}

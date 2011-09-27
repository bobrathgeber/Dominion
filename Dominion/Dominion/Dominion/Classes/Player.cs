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
using System.Text;

namespace Dominion
{
    class Player
    {
        public List<Card> deck;
        public List<Card> discard;
        public List<Card> hand;

        public string name;
        protected int actions;
        protected int buys;
        protected int coins;

        public Player()
        {
            
            deck = new List<Card>();
            discard = new List<Card>();
            hand = new List<Card>();

        }

        public int Actions
        {
            get { return actions;}
            set { actions = value; }
        }

        public int Buys
        {
            get { return buys; }
            set { buys = value; }
        }

        public int Coins
        {
            get { return coins; }
            set { coins = value; }
        }

        public void playCard(int cardPosition)
        {
            //removes card @ cardPosition from hand
        }

        public void drawCard(int numberOfCards)
        {
            for(int n = 0; n < numberOfCards; n++)
            {

                if (deck.Count == 0)
                {                  
                    for (int i = 0; i<discard.Count; i++)
                    {
                        deck.Add(discard[i]);                      
                    }

                    discard.Clear();
                    shuffleDeck();
                }
                
                hand.Add(deck[0]);
                deck.RemoveAt(0);            
            }
            //foreach (Card c in deck)
            //{
            //    Console.WriteLine(c);
            //}
        }

        public void addCardToHand(Card newCard)
        {

            //removes top card from deck
            //adds card to hand
        }

        public void shuffleDeck()
        {
            var rand = new Random();
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                Card temp = deck[i];
                deck[i] = deck[n];
                deck[n] = temp;
            }
        }

        public void addCardToDiscard(Card newCard)
        {
            deck.Add(newCard);
        }

        public void trashCard()
        {

        }

        public void endTurn()
        {
            foreach (Card c in hand.ToList())
            {
                discard.Add(c);
                hand.Remove(c);
            }
            drawCard(5);
            actions = 1;
            buys = 1;
            coins = 0;
        }

        public List<Card> getHand()
        {
            return hand;
        }
    }
}

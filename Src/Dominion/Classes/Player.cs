﻿using System;
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
using Dominion.Classes;

namespace Dominion
{
    public class Player
    {

        public List<Card> deck;
        public List<Card> discard;
        public Hand hand;
        public Store Store { get; set; }

        public bool canSelectHand;
        public bool canSelectStore;

        public string name;
        protected int actions;
        protected int buys;
        protected int coins;

        public Player()
        {
            deck = new List<Card>();
            discard = new List<Card>();
            hand = new Hand();
            canSelectHand = false;
            canSelectStore = false;
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

        public void Play(Card c)
        {
            // TODO: this shouldn't be delegating to card

            c.play(this);
        }

        public void pickupCard(int numberOfCards)
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
                var card = deck[0];
                deck.RemoveAt(0);

                hand.Add(card);
            }
        }

        public void addCardToHand(Card newCard)
        {

            //removes top card from deck
            //adds card to hand
        }

        public void BuyCard(Card c)
        {
            Store.buyCard(this, c);
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
            pickupCard(5);
            actions = 1;
            buys = 1;
            coins = 0;
        }

        public List<Card> getHand()
        {
            return hand;
        }

        public void moveCard(Card c, Hand origin, List<Card> destination)
        {
            destination.Add(c);
            origin.Remove(c);
        }

        public int getTotalCards()
        {
            int totalCards = 0;
            
            foreach (Card c in deck)
            {
                totalCards += 1;
            }
            foreach (Card c in hand)
            {
                totalCards += 1;
            }
            foreach (Card c in discard)
            {
                totalCards += 1;
            }
            return totalCards;
        }
        public int getVP()
        {
            int totalVP = 0;
            foreach (Card c in deck)
            {
                totalVP += c.VP;
            }
            foreach (Card c in hand)
            {
                totalVP += c.VP;
            }
            foreach (Card c in discard)
            {
                totalVP += c.VP;
            }
            return totalVP;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void TryBuyCard(string cardName)
        {
            //store.buyCard(this, c);
        }
    }
}

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
    public abstract class Card
    {
        public bool isSelected;
        public Rectangle position;
        public Texture2D cardImage;
        protected Player owner;

        protected int cost;
        protected string name;
        protected int _VP;

        MouseState mouse;
        MouseState oldMouse;
        
        public Card(string n, int c, Player o)
        {
            Name = n;
            Cost = c;
            owner = o;
            isSelected = false;
            position = new Rectangle();
        }

        public int Cost
        {
            set { cost = value; }
            get { return cost; }
        }

        public String Name
        {
            set { name = value; }
            get { return name; }
        }

        public int VP
        {
            get { return _VP;  }
        }

        protected void LoadTexture(string path)
        {
            var manager = ServiceLocator.ContentManager;
            cardImage = manager.Load<Texture2D>(path);
            //no owner means its a store image
            if (owner == null)
            {
                position.Height = cardImage.Height / 2;
                position.Width = cardImage.Width / 2;
            }
            else
            {
                position.Height = cardImage.Height;
                position.Width = cardImage.Width;
            }
        }

        public void Update()
        {
            mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Released && oldMouse.LeftButton == ButtonState.Pressed)
            {
                if (position.Contains(new Point(mouse.X, mouse.Y)))
                {
                    play();
                }
            }
            oldMouse = mouse;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (position.Contains(new Point(mouse.X, mouse.Y)))
            {
                spriteBatch.Draw(cardImage, position, Color.Silver);
            }
            else if (isSelected)
            {
                spriteBatch.Draw(cardImage, position, Color.Red);
            }
            else
            {
                spriteBatch.Draw(cardImage, position, Color.White);
            }
            
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual void play()
        {
            //move card from hand to discard
        }
    }
}

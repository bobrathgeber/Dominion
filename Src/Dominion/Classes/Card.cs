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
using Dominion.Classes;

namespace Dominion
{
    public abstract class Card : Entity,
        IRenderable
    {
        private Boolean _highlight;
        private Boolean _selected;
        public Rectangle position;
        public Texture2D Image;
        protected Player owner;

        protected int cost;
        protected string name;
        protected int _VP;
        
        public Card(string n, int c, Player o)
        {
            Name = n;
            Cost = c;
            owner = o;
            _selected = false;
            _highlight = false;
            position = new Rectangle();
            Visible = true;
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
            Image = manager.Load<Texture2D>(path);
        }

        public void Buy()
        {
            //_store.buyCard(owner, this);
        }


        public override string ToString()
        {
            return Name;
        }

        public virtual void play()
        {
            //move card from hand to discard
        }

        public Boolean Visible { get; set; }

        public void Location(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public void Scale(int w, int h)
        {
            position.Width = w;
            position.Height = h;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_highlight)
            {
                spriteBatch.Draw(Image, position, Color.Silver);
            }
            else if (_selected)
            {
                spriteBatch.Draw(Image, position, Color.Red);
            }
            else if (Visible)
            {
                spriteBatch.Draw(Image, position, Color.White);
            }

        }
    }
}

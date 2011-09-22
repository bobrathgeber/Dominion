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
    public abstract class Card
    {
        public Vector2 position;
        public Texture2D cardImage;
        public bool active;
        private string name;
        public int VP;
        
        public Card(string Name, int Cost)
        {
            name = Name;
            VP = 0;
            position = new Vector2(0, 0);
            active = false;
        }

        protected void LoadTexturue(string path)
        {
            var manager = ServiceLocator.ContentManager;
            cardImage = manager.Load<Texture2D>(path);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cardImage, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public override string ToString()
        {
            return name;
        }
    }
}

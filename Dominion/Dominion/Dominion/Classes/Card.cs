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
    public abstract class Card
    {
        public Vector2 position;
        public Texture2D cardImage;
        public bool active;
        public string imagePath;

        
        public void Initialize(string Name, int Cost, Texture2D image, ContentManager manager)
        {
            
            position = new Vector2(0, 0);
            active = false;    
            cardImage = manager.Load<Texture2D>(imagePath);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cardImage, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}

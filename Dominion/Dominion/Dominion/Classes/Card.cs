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
        public Rectangle position;
        public Texture2D cardImage;
        public bool active;
        private string name;
        public int VP;

        MouseState mouse;
        MouseState oldMouse;
        
        public Card(string Name, int Cost)
        {
            name = Name;
            VP = 0;
            active = false;
        }

        protected void LoadTexturue(string path)
        {
            var manager = ServiceLocator.ContentManager;
            cardImage = manager.Load<Texture2D>(path);
            position = new Rectangle(0, 0, cardImage.Width, cardImage.Height);
        }

        public void Update()
        {
            mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Released && oldMouse.LeftButton == ButtonState.Pressed)
            {
                if (position.Contains(new Point(mouse.X, mouse.Y)))
                {
                    play();
                    //clicked = true;
                }

            }
            else
            {
                //clicked = false;
            }


            oldMouse = mouse;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (position.Contains(new Point(mouse.X, mouse.Y)))
            {
                spriteBatch.Draw(cardImage,
                    position,
                    Color.Silver);
                Console.Write("done");

            }
            else
            {
                spriteBatch.Draw(cardImage, position, Color.White);
            }
            
        }

        public override string ToString()
        {
            return name;
        }

        public virtual void play()
        {
            Console.Write("done");
        }
    }
}

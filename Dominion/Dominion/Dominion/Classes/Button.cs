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

namespace Dominion.Classes
{
    class Button
    {
        private IButtonAction _action;
        Texture2D image;
        SpriteFont font;
        Rectangle position;
        string text;
        Vector2 textLocation;
        SpriteBatch spriteBatch;
        MouseState mouse;
        MouseState oldMouse;
        bool clicked = false;
        //string clickText = "Button was Clicked!";

        public Button(Texture2D texture, SpriteFont font, SpriteBatch sBatch, IButtonAction action)
        {
            _action = action;
            image = texture;
            this.font = font;
            position = new Rectangle(0, 0, image.Width, image.Height);
            spriteBatch = sBatch;
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                Vector2 size = font.MeasureString(text);
                textLocation = new Vector2();
                textLocation.Y = position.Y + ((image.Height / 2) - (size.Y / 2));
                textLocation.X = position.X + ((image.Width / 2) - (size.X / 2));
            }
        }

        public void Location(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public void Click()
        {
            _action.Execute();
        }

        public void Update()
        {
            mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Released && oldMouse.LeftButton == ButtonState.Pressed)
            {
                if (position.Contains(new Point(mouse.X, mouse.Y)))
                {
                    clicked = true;
                }

            }
            else
            {
               clicked = false;
            }
            oldMouse = mouse;
        }

        public void Draw()
        {
            //used to say spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            //spriteBatch.Begin();

            if (position.Contains(new Point(mouse.X, mouse.Y)))
            {
                spriteBatch.Draw(image,
                    position,
                    Color.Silver);
               
            }
            else
            {
                spriteBatch.Draw(image,
                    position,
                    Color.White);
            }

            //spriteBatch.DrawString(font, text, textLocation, Color.Black);
            
            if (clicked)
            {
                Click();
                //Vector2 position = new Vector2(10, 75);
                //spriteBatch.DrawString(font, clickText, position, Color.White);
            }

            //spriteBatch.End();
        } 

    }
}

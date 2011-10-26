using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Dominion.Classes
{
    public class Label
        : Entity, IRenderable
    {
        private Vector2 _boundingBox;
        private string _text;
        private SpriteFont _font;

        public Label()
            : this("gameFont")
        {
        }

        public Label(string fontName)
        {
            _font = Registry.ContentManager.Load<SpriteFont>(fontName);
            _text = "";
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }

        public Vector2 GetSize()
        {
            return _font.MeasureString(_text);
        }

        public Vector2 BoundingBox
        {
            get
            {
                return _boundingBox;
            }
            set
            {
                _boundingBox = value;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (_text != null)
            {
                batch.DrawString(_font, _text, BoundingBox, Color.White);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Template
{
    class TextWriter
    {
        SpriteFont font;

        public TextWriter(ContentManager content)
        {
            font = content.Load<SpriteFont>("font1");
        }

        public void RenderText(SpriteBatch spriteBatch, string text, Vector2 position, Color color)
        {
            spriteBatch.DrawString(font, text, position, color);
        }
    }
}

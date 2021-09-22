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
    class ScoreTracking
    {
        TextWriter TextWriter;
        float Score = 0;

        public ScoreTracking(ContentManager content)
        {
            TextWriter = new TextWriter(content);
        }

        public void UpdateScore(float score)
        {
            Score = score;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            TextWriter.RenderText(spriteBatch, "Score: " + Score, new Vector2(1815, 260), Color.White);
        }
    }
}

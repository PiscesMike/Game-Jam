using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Template
{
    class Star
    {
        Vector2 Position, Trajectory, Scale;
        Texture2D Asset;
        
        public Star(ContentManager content, Random random)
        {
            Asset = content.Load<Texture2D>("1");

            Position.X = (float)random.NextDouble() * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            Position.Y = (float)random.NextDouble() * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            Scale = new Vector2(((float)random.NextDouble()) + 0.25f);
            Trajectory = new Vector2(0, ((float)random.NextDouble()*8));
        }

        public void Update()
        {
            Position += Trajectory;
            if (Position.Y >= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height) Position.Y = 0;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Asset, Position, null, Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0.0f);
        }
    }
}

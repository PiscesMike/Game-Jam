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
    class Round : iProjectile
    {
        Texture2D Asset;
        Vector2 Position, Trajectory;

        float Speed = 5;
        float Damage = 1f;

        bool isAlive = true;

        public Round(ContentManager content, Vector2 position, Vector2 trajectory)
        {
            Asset = content.Load<Texture2D>("3");
            Position = position;
            Trajectory = trajectory;
        }

        public void Update()
        {
            float motion = -(Speed * Trajectory.Y);
            Position = new Vector2(Position.X, Position.Y - motion);
            if (Position.Y <= 0) HasImpacted();
        }

        public float GetDamage()
        {
            return Damage;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Asset, Position, Color.White);
        }

        public void HasImpacted()
        {
            isAlive = false;
        }

        public bool IsAlive()
        {
            return isAlive;
        }

        public Vector2 GetPosition()
        {
            return Position;
        }
    }
}

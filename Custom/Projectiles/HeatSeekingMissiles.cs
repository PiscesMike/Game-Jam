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
    class HeatSeekingMissiles : iProjectile
    {
        Texture2D Asset;
        Vector2 Position, Trajectory;
        Vector2 EnemyPosition = Vector2.Zero;

        Enemy EnemyTarget;

        float Speed = 6;
        float Damage = 50f;

        bool isAlive = true;

        public HeatSeekingMissiles(ContentManager content, Vector2 position, Vector2 trajectory, Enemy enemy)
        {
            Asset = content.Load<Texture2D>("Missile");
            Position = position;
            Trajectory = trajectory;
            EnemyTarget = enemy;
        }

        public void Update()
        {
           if(EnemyTarget!=null) EnemyPosition = EnemyTarget.GetPosition();

            Vector2 motion = Position - EnemyPosition;

            motion.Normalize();
            motion = motion * 3.5f;
            motion += -(Speed * Trajectory);

            Position = new Vector2(Position.X-motion.X, Position.Y - motion.Y);
            if (Position.Y <= 0) HasImpacted();
        }

        public float GetDamage()
        {
            return Damage;
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public void HasImpacted()
        {
            isAlive = false;
        }

        public bool IsAlive()
        {
            return isAlive;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Asset, Position, Color.White);
        }
    }
}

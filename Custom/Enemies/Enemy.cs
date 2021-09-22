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
    class Enemy
    {
        Vector2 Position;
        Texture2D Asset;
        iEnemyMotionController MotionController;
        float HitPoints = 20;
        public bool isAlive = true;

        CollisionDetection CollisionDetection;

        SpriteFont font;

        public Enemy(ContentManager content, Vector2 position, Vector2 trajectory, string asset, iEnemyMotionController motionController)
        {
            Asset = content.Load<Texture2D>(asset);
            Position = position;

            MotionController = motionController;
            CollisionDetection = new CollisionDetection();

            font = content.Load<SpriteFont>("font1");
        }

        public void Update(List<iProjectile> shotsFired)
        {
            Position = MotionController.Update(Position);

            foreach (iProjectile thisBullet in shotsFired)
                if (CollisionDetection.Collision(thisBullet, this))
                {
                    TakesDamage(thisBullet.GetDamage());
                    thisBullet.HasImpacted();
                }
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public void TakesDamage(float damage)
        {
            HitPoints -= damage;
            if (HitPoints <= 0) isAlive = false;
        }

        public bool Alive()
        {
            return isAlive;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Asset, Position, Color.White);
            //spriteBatch.DrawString(font, HitPoints.ToString(), Position, Color.Red);
        }
    }
}

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
    class LaserCannon : iPlayerWeapon
    {
        Texture2D Asset;
        List<iProjectile> Blasts = new List<iProjectile>();
        ContentManager Content;
        float RepeatDelay = 100f;
        bool ReadyToFire = true;
        float NumberOfRounds = 1000;
        TextWriter TextWriter;

        bool Direction = false;
        Vector2 Trajectory;

        public LaserCannon(ContentManager content)
        {
            Content = content;
            Asset = content.Load<Texture2D>("Laser");

            TextWriter = new TextWriter(content);
            Trajectory = new Vector2(0, -1);
        }

        public void FireShot(Vector2 position)
        {
            Vector2 bulletPosition = new Vector2(position.X + (Asset.Width / 8), position.Y - (Asset.Height / 8));

            if (ReadyToFire && NumberOfRounds > 0)
            {
                Blasts.Add(new Blast(Content, bulletPosition, Trajectory));
                NumberOfRounds--;
                Blasts.RemoveAll(x => x.IsAlive() == false);
            }

            ReadyToFire = false;
        }

        public List<iProjectile> GetShotsFired()
        {
            return Blasts;
        }

        public void Update()
        {
            foreach (Blast thisBlast in Blasts) thisBlast.Update();
        }

        public void Render(SpriteBatch spriteBatch)
        {
            if (Direction) Trajectory = new Vector2(0, 1);
            foreach (Blast thisBlast in Blasts) thisBlast.Render(spriteBatch);
            spriteBatch.Draw(Asset, new Vector2(1820, 200), Color.White);
            TextWriter.RenderText(spriteBatch, NumberOfRounds.ToString(), new Vector2(1820, 235), Color.Red);
        }

        public float GetTriggerDelay()
        {
            return RepeatDelay;
        }

        public void ResetTrigger()
        {
            ReadyToFire = true;
        }

        public void SetTrajectory(bool direction)
        {
            Direction = direction;
        }
        public void FireShot(Vector2 position, Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}

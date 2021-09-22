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
    class RocketLauncher : iPlayerWeapon
    {
        Texture2D Asset;
        List<iProjectile> Missiles = new List<iProjectile>();
        ContentManager Content;
        float RepeatDelay = 200;
        bool ReadyToFire = true;
        float NumberOfRounds = 1600;

        TextWriter TextWriter;

        public RocketLauncher(ContentManager content)
        {
            Content = content;
            Asset = content.Load<Texture2D>("Rocket");

            TextWriter = new TextWriter(content);
        }

        public void FireShot(Vector2 position, Enemy thisEnemy)
        {
            Vector2 missilePosition = new Vector2(position.X - (Asset.Width / 12), position.Y - (Asset.Height / 4));

            if (ReadyToFire && NumberOfRounds > 0)
            {
                Missiles.Add(new HeatSeekingMissiles(Content, missilePosition, new Vector2(0, -1), thisEnemy));
                NumberOfRounds--;
                Missiles.RemoveAll(x => x.IsAlive() == false);
            }

            ReadyToFire = false;
        }

        public List<iProjectile> GetShotsFired()
        {
            return Missiles;
        }

        public void Update()
        {
            foreach (HeatSeekingMissiles thisMissile in Missiles) { thisMissile.Update();}
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (HeatSeekingMissiles thisMissile in Missiles) thisMissile.Render(spriteBatch);
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

        public void FireShot(Vector2 position)
        {
        }
    }
}
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
    class Gun : iPlayerWeapon
    {
        Texture2D Asset;
        List<iProjectile> Shots = new List<iProjectile>();
        ContentManager Content;
        float RepeatDelay = 250;
        bool ReadyToFire = true;
        float NumberOfRounds = 200;
        TextWriter TextWriter;

        public Gun(ContentManager content)
        {
            Content = content;
            Asset = Content.Load<Texture2D>("Bullets");

            TextWriter = new TextWriter(content);
        }

        public void FireShot(Vector2 position)
        {
            Vector2 bulletPosition = new Vector2(position.X + (Asset.Width / 8), position.Y);
            if (ReadyToFire && NumberOfRounds > 0)
            {
                Shots.Add(new Round(Content, bulletPosition, new Vector2(0, -1)));
                NumberOfRounds--;
                Shots.RemoveAll(x => x.IsAlive() == false);
            }
            ReadyToFire = false;
        }

        public void Update()
        {
            foreach (Round thisRound in Shots) thisRound.Update();
        }

        public List<iProjectile> GetShotsFired()
        {
            return Shots;
        }

        public float GetTriggerDelay()
        {
            return RepeatDelay;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (Round thisRound in Shots) thisRound.Render(spriteBatch);

            spriteBatch.Draw(Asset, new Vector2(1820, 200), Color.White);
            TextWriter.RenderText(spriteBatch, NumberOfRounds.ToString(), new Vector2(1820, 175), Color.Red);
        }

        public void ResetTrigger()
        {
            ReadyToFire = true;
        }

        public void FireShot(Vector2 position, Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}

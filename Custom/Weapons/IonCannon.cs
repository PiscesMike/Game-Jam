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
    class IonCannon : iPlayerWeapon
    {
        Texture2D Asset;
        List<iProjectile> Blasts = new List<iProjectile>();
        ContentManager Content;
        float RepeatDelay = 2000;
        bool ReadyToFire = true;
        float NumberOfRounds = 1000;
        float EnergyLevel = 0;
        TextWriter TextWriter;

        public IonCannon(ContentManager content)
        {
            Content = content;
            Asset = content.Load<Texture2D>("Ion");

            TextWriter = new TextWriter(content);
        }

        public void FireShot(Vector2 position)
        {
            if (EnergyLevel < 100) return;
            Vector2 bulletPosition = new Vector2(position.X - (Asset.Width / 12), position.Y-(Asset.Height/4));

            if (ReadyToFire && NumberOfRounds > 0)
            {
                Blasts.Add(new IonBlasts(Content, bulletPosition, new Vector2(0, -1)));
                NumberOfRounds--;
                Blasts.RemoveAll(x => x.IsAlive() == false);
            }

            ReadyToFire = false; EnergyLevel = 0;
        }

        public List<iProjectile> GetShotsFired()
        {
            return Blasts;
        }

        public void Update()
        {
            if (EnergyLevel < 100) EnergyLevel++;
            foreach (IonBlasts thisBlast in Blasts) thisBlast.Update();
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (IonBlasts thisBlast in Blasts) thisBlast.Render(spriteBatch);
            spriteBatch.Draw(Asset, new Vector2(1820, 200), Color.White);

            TextWriter.RenderText(spriteBatch, NumberOfRounds.ToString(), new Vector2(1820, 175), Color.Red);

            Color EnergyColor=Color.Green;
            if (EnergyLevel < 100) EnergyColor = Color.Orange;
            if (EnergyLevel < 60) EnergyColor = Color.Red;

            TextWriter.RenderText(spriteBatch, EnergyLevel.ToString(), new Vector2(1820, 235), EnergyColor);
        }

        public float GetTriggerDelay()
        {
            return RepeatDelay;
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


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
    interface iPlayerWeapon
    {
        void Render(SpriteBatch spriteBatch);
        void FireShot(Vector2 position);
        void FireShot(Vector2 position, Enemy enemy);
        void Update();
        List<iProjectile> GetShotsFired();
        float GetTriggerDelay();
        void ResetTrigger();
    }
}

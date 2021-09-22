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
    class CollisionDetection : iCollider
    {
        public bool Collision(iProjectile thisBullet, Enemy enemy)
        {
            if (thisBullet.GetPosition().Y <= enemy.GetPosition().Y && thisBullet.GetPosition().Y>=enemy.GetPosition().Y-16 && thisBullet.GetPosition().X >= enemy.GetPosition().X && thisBullet.GetPosition().X <= enemy.GetPosition().X + 16) return true;

            return false;
        }
    }
}

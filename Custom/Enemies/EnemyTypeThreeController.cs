using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
 
namespace Template
{
    class EnemyTypeThreeController : iEnemyMotionController
    {
        Vector2 OriginalPosition, Trajectory, Bounds;
        float Rotation = 0;

        public EnemyTypeThreeController(Vector2 originalPosition, Vector2 trajectory)
        {
            Trajectory = trajectory;

            OriginalPosition = originalPosition;
            Bounds = new Vector2(originalPosition.X + 200, originalPosition.X-200);
        }

        public Vector2 Update(Vector2 Position)
        {
            Position += Trajectory;

            Rotation += 5;
            if (Rotation > 360) Rotation = 0;

            double newPositionX = 100 * Math.Cos(Rotation * Math.PI / 180.0f);
            double newPositionY = 100 * Math.Sin(Rotation * Math.PI / 180.0f);

            Position = new Vector2((float)newPositionX, (float)newPositionY) + OriginalPosition;
            return Position;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class EnemyTypeTwoController : iEnemyMotionController
    {
        Vector2 OriginalPosition, Trajectory, Bounds;

        public EnemyTypeTwoController(Vector2 originalPosition, Vector2 trajectory)
        {
            Trajectory = trajectory;

            OriginalPosition = originalPosition;
            Bounds = new Vector2(originalPosition.X + 200, originalPosition.X-200);
        }

        public Vector2 Update(Vector2 Position)
        {
            Position += Trajectory;
            //if (Position.X > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 50 || Position.X < 50) Trajectory = -Trajectory;
            if (Position.X > Bounds.X || Position.X<Bounds.Y) Trajectory = -Trajectory;
            return Position;
        }

    }
}

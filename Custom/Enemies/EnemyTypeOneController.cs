using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Template
{
    class EnemyTypeOneController : iEnemyMotionController
    {
        Vector2 OriginalPosition, Trajectory;
        float DriftXPositive, DriftXNegative;
        float DriftYPositive, DriftYNegative;

        public EnemyTypeOneController(Vector2 originalPosition, Vector2 trajectory)
        {
            Trajectory = trajectory;

            OriginalPosition = originalPosition;

            DriftXNegative = originalPosition.X - 30;
            DriftXPositive = originalPosition.X + 30;
            DriftYNegative = originalPosition.Y - 90;
            DriftYPositive = originalPosition.Y + 90;

        }

        public Vector2 Update(Vector2 Position)
        {
            Position += Trajectory;

            if (Position.X > DriftXPositive) Trajectory.X = -Trajectory.X;
            if (Position.X < DriftXNegative) Trajectory.X = -Trajectory.X;
            if (Position.Y > DriftYPositive) Trajectory.Y = -Trajectory.Y;
            if (Position.Y < DriftYNegative) Trajectory.Y = -Trajectory.Y;

            return Position;
        }

    }
}

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
    interface iEnemyMotionController
    {
     //   void StandardEnemyMotion(Vector2 OriginalPosition);
        Vector2 Update(Vector2 Position);       
    }
}

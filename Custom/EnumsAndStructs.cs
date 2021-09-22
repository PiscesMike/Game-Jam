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
    public struct RenderingObjects
    {
        public GraphicsDeviceManager Graphics;
        public ContentManager Content;
        public GameTime GameTime;
        public SpriteBatch SpriteBatch;
    }

    class Enums
    {
        public enum PlayerCommands
        {
            None,
            Move_Right,
            Move_Left,
            Fire_Weapon,
            Weapon_Up,
            Weapon_Down
        }

    }
}

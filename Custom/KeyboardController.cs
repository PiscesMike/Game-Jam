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
    class KeyboardController : iPlayerController
    {
        public Enums.PlayerCommands Update(KeyboardState keyboardState)
        {
            Keys[] keys = keyboardState.GetPressedKeys();

            foreach (Keys thisKey in keys)
                switch (thisKey)
                {
                    case Keys.Right:
                        return Enums.PlayerCommands.Move_Right;

                    case Keys.Left:
                        return Enums.PlayerCommands.Move_Left;

                    case Keys.Space:
                        return Enums.PlayerCommands.Fire_Weapon;

                    case Keys.Up:
                        return Enums.PlayerCommands.Weapon_Up;

                    case Keys.Down:
                        return Enums.PlayerCommands.Weapon_Down;
                }

            return Enums.PlayerCommands.None;
        }
    }
}

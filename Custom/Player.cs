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
    class Player
    {
        Vector2 Position;
        Texture2D Asset;
        KeyboardController KeyboardController;
        List<iPlayerWeapon> Weapons;
        int SelectedWeapon = 0;
        float RepeatDelay;
        float KeyTimer = 500, GameTimer = 0;
        bool KeyReset = true;

        iPlayerWeapon CurrentWeapon;

        public Player(ContentManager content, Vector2 position)
        {
            Asset = content.Load<Texture2D>("Player");
            Position = position;

            KeyboardController = new KeyboardController();
            Weapons = new List<iPlayerWeapon>();

            Weapons.Add(new Gun(content));
            Weapons.Add(new LaserCannon(content));
            Weapons.Add(new IonCannon(content));
            Weapons.Add(new RocketLauncher(content));

            SetWeapon(SelectedWeapon);
        }

        public void Update(float gameTimer, Enemy thisEnemy)
        {
            GameTimer += gameTimer;
            if (GameTimer >= KeyTimer) { KeyReset = true; GameTimer = 0; }

            Enums.PlayerCommands Commands = KeyboardController.Update(Keyboard.GetState());

            if (Commands == Enums.PlayerCommands.Move_Left)
                if (Position.X > 30) Position.X -= 5;

            if (Commands == Enums.PlayerCommands.Move_Right)
                if (Position.X < 1860) Position.X += 5;

            if (Commands == Enums.PlayerCommands.Fire_Weapon)
            {
                if (SelectedWeapon != 3) { CurrentWeapon.FireShot(Position); } else { CurrentWeapon.FireShot(Position, thisEnemy); }
            }

            if (KeyReset)
            {
                if (Commands == Enums.PlayerCommands.Weapon_Down) AdvanceWeapon();
                if (Commands == Enums.PlayerCommands.Weapon_Up) RetreatWeapon();
            }

            foreach (iPlayerWeapon thisWeapon in Weapons)
            {
                thisWeapon.Update();
            }

            int keyCount = Keyboard.GetState().GetPressedKeys().Count();
            if (keyCount > 0) KeyReset = false;
        }

        public iPlayerWeapon GetWeapon()
        {
            return CurrentWeapon;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Asset, Position, Color.White);
            CurrentWeapon.Render(spriteBatch);
        }

        private void RetreatWeapon()
        {
            if (SelectedWeapon >= (Weapons.Count()-1)) SelectedWeapon = -1;
            SelectedWeapon++;

            SetWeapon(SelectedWeapon);
        }

        private void AdvanceWeapon()
        {
            SelectedWeapon--;
            if (SelectedWeapon < 0) SelectedWeapon = Weapons.Count() - 1;

            SetWeapon(SelectedWeapon);
        }

        private void SetWeapon(int selectedWeapon)
        {
            CurrentWeapon = Weapons[SelectedWeapon];
            RepeatDelay = CurrentWeapon.GetTriggerDelay();
        }
    }
}

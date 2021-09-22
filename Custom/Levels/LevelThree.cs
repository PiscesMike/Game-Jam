using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Template;

namespace Template
{
    class LevelThree : iGameState
    {
        Background Background;
        EnemyManager EnemyManager;
        Enemy nullEnemy;
        Player Player;

        EnemiesLevelThree Enemies;

        float WeaponTimer, GameTimer = 0;
        bool HasWon = false;

        public LevelThree(RenderingObjects renderingObjects)
        {
            Enemies = new EnemiesLevelThree(renderingObjects.Content);
            Background = new Background(renderingObjects.Content);
            EnemyManager = new EnemyManager(Enemies.GetEnemies());
            Player = new Player(renderingObjects.Content, new Vector2(500, 850));

            WeaponTimer = Player.GetWeapon().GetTriggerDelay();
        }

        public void Initialize(ContentManager content)
        {

        }

        public void LoadContent()
        {

        }

        public bool StateChange()
        {
            return HasWon;
        }

        public void Update(GameTime gameTime)
        {
            Background.Update();
            EnemyManager.Update(Player.GetWeapon().GetShotsFired());

            if (Enemies.GetEnemies().Count > 0)
            {
                Player.Update(gameTime.ElapsedGameTime.Milliseconds, Enemies.GetEnemies()[0]);
            }
            else
            {
                Player.Update(gameTime.ElapsedGameTime.Milliseconds, nullEnemy);
                HasWon = true;
            }

            GameTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (GameTimer >= WeaponTimer)
            {
                GameTimer = 0;
                Player.GetWeapon().ResetTrigger();
                WeaponTimer = Player.GetWeapon().GetTriggerDelay();
            }
        }

        public void Render(SpriteBatch spriteBatch)
        {
            Background.Render(spriteBatch);
            EnemyManager.Render(spriteBatch);
            Player.Render(spriteBatch);
        }

        public string GetStateName()
        {
            return "LevelThree";
        }
    }
}

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
    class LevelOne : iGameState
    {
        Background Background;
        EnemyManager EnemyManager;
        Enemy nullEnemy;
        Player Player;

        EnemiesLevelOne Enemies;

        Texture2D Cell;
        ScoreTracking ScoreTracker;

        float WeaponTimer, GameTimer = 0;
        float Score = 0;
        bool HasWon = false;

        public LevelOne(RenderingObjects renderingObjects)
        {
            Enemies = new EnemiesLevelOne(renderingObjects.Content);
            Background = new Background(renderingObjects.Content);
            EnemyManager = new EnemyManager(Enemies.GetEnemies());
            Player = new Player(renderingObjects.Content, new Vector2(500, 850));

            ScoreTracker = new ScoreTracking(renderingObjects.Content);

            WeaponTimer = Player.GetWeapon().GetTriggerDelay();
            Cell = renderingObjects.Content.Load<Texture2D>("Cell");
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
                ScoreTracker.UpdateScore((36 - Enemies.GetEnemies().Count) * 10);
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

            spriteBatch.Draw(Cell, new Vector2(1815, 195), Color.White);
            ScoreTracker.Render(spriteBatch);

            Player.Render(spriteBatch);
        }

        public string GetStateName()
        {
            return "LevelOne";
        }

        public void Scored()
        {
            Score += 10;
        }

        public void Reset()
        {
            HasWon = false;
        }
    }
}

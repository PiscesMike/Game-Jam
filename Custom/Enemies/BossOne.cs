using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class BossOne : iGameState
    {
        Background Background;
        Player Player;
        Enemy nullEnemy;
        TextWriter TextWriter;

        List<Texture2D> KeyFrames = new List<Texture2D>();
        Texture2D HotZone;

        RenderingObjects Rendering;

        bool HasWon = false;
        string StateName = "BossOne";

        int CurrentFrame = 0;

        float FrameTime = 50.0f, CurrentTime = 0.0f;
        float GameTimer, WeaponTimer;
        float BossHealth = 10000.0f;

        Rectangle BossHitZoneOne, BossHitZoneTwo;

        Vector2 Position, Trajectory;

        Color BossColor = Color.White;

        public BossOne(RenderingObjects rendering)
        {
            Rendering = rendering;

            KeyFrames.Add(LoadTexture("Attack_01_000"));
            KeyFrames.Add(LoadTexture("Attack_01_001"));
            KeyFrames.Add(LoadTexture("Attack_01_002"));
            KeyFrames.Add(LoadTexture("Attack_01_003"));
            KeyFrames.Add(LoadTexture("Attack_01_004"));
            KeyFrames.Add(LoadTexture("Attack_01_005"));
            KeyFrames.Add(LoadTexture("Attack_01_006"));
            KeyFrames.Add(LoadTexture("Attack_01_007"));
            KeyFrames.Add(LoadTexture("Attack_01_008"));
            KeyFrames.Add(LoadTexture("Attack_01_009"));

            HotZone = LoadTexture("Cell");

            Position = new Vector2(401, 100);
            Trajectory = new Vector2(1, 0);

            Background = new Background(Rendering.Content);
            Player = new Player(Rendering.Content, new Vector2(500, 850));

            WeaponTimer = Player.GetWeapon().GetTriggerDelay();

            BossHitZoneOne = new Rectangle(new Point(625, 500), new Point(50, 50));
            BossHitZoneTwo = new Rectangle(new Point(1210, 500), new Point(50, 50));

            TextWriter = new TextWriter(Rendering.Content);
        }

        public string GetStateName()
        {
            return StateName;
        }

        public void Initialize(ContentManager content)
        {

        }

        public void LoadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            BossColor = Color.White;

            GameTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (GameTimer >= WeaponTimer)
            {
                GameTimer = 0;
                Player.GetWeapon().ResetTrigger();
                WeaponTimer = Player.GetWeapon().GetTriggerDelay();
            }

            Background.Update();
            Player.Update(gameTime.ElapsedGameTime.Milliseconds, nullEnemy);

            CurrentTime += (float)gameTime.ElapsedGameTime.Milliseconds;

            if (CurrentTime >= FrameTime)
            {
                CurrentTime = 0;
                CurrentFrame++;
                if (CurrentFrame > 9) CurrentFrame = 0;
            }

            Position += Trajectory;

            BossHitZoneOne.X += (int)Trajectory.X;
            BossHitZoneTwo.X += (int)Trajectory.X;

            if (Position.X > 800) Trajectory.X = -Trajectory.X;
            if (Position.X < 100) Trajectory.X = -Trajectory.X;

            foreach(iProjectile thisProjectile in Player.GetWeapon().GetShotsFired())
            {
                if (BossHitZoneOne.Intersects(new Rectangle((int)thisProjectile.GetPosition().X, (int)thisProjectile.GetPosition().Y, 10, 10))) { BossHealth -= thisProjectile.GetDamage(); BossColor = Color.Red; }
                    if (BossHitZoneTwo.Intersects(new Rectangle((int)thisProjectile.GetPosition().X, (int)thisProjectile.GetPosition().Y, 10, 10))) { BossHealth -= thisProjectile.GetDamage(); BossColor = Color.Red; }
            }

            if (BossHealth <= 0) HasWon = true;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            Background.Render(spriteBatch);
            if(!HasWon) spriteBatch.Draw(KeyFrames[CurrentFrame], Position, BossColor);
            //spriteBatch.Draw(HotZone, BossHitZoneOne, Color.White);
            //spriteBatch.Draw(HotZone, BossHitZoneTwo, Color.White);
            Player.Render(spriteBatch);
            TextWriter.RenderText(spriteBatch, BossHealth.ToString(), new Vector2(1820, 275), Color.AliceBlue);
        }

        public bool StateChange()
        {
            return HasWon;
        }

        public Texture2D LoadTexture(string asset)
        {
            return Rendering.Content.Load<Texture2D>(asset);
        }
    }
}

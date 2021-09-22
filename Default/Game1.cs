using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Background Background;
        EnemyManager Enemies;
        Enemy nullEnemy;
        Player Player;

        bool WeaponReset = true;
        float WeaponTimer, GameTimer = 0;

        StateManagerII StateManager;                                                  // Instanciate our StateManager class to manage our game states.

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;

            //graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            /*Background = new Background(Content);
            Enemies = new EnemyManager(Content);
            Player = new Player(Content, new Vector2(500, 850));

            WeaponTimer = Player.GetWeapon().GetTriggerDelay();

            //GameState = new GameState(Background, Player, Enemies);*/

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            StateManager = new StateManagerII(graphics, Content, spriteBatch);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            StateManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            // This is where we call the rendering class to do all the drawing
            StateManager.Render();

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

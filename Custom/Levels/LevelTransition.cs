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
    class LevelTransition : iGameState
    {
        bool StateChanged = false;
        float time = 0;

        string StateName = "Transition";
        ContentManager Content;
        TextWriter TextWriter;

        RenderingObjects Rendering;

        public LevelTransition(RenderingObjects rendering)
        {
            Content = rendering.Content;
            TextWriter = new TextWriter(Content);
        }

        public void Initialize(ContentManager content)
        {

            // May need to remove if it goes unused
        }

        public void LoadContent()
        {
            // May need to remove if it goes unused
        }

        public void Update(GameTime gameTime)
        {
            // Updating
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time > 5000f) StateChanged = true;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            TextWriter.RenderText(spriteBatch, StateName, new Vector2(900, 600), Color.White);
            // Rendering
        }

        public bool StateChange()
        {
            return StateChanged;
        }

        public string GetStateName()
        {
            return "LevelTransition";
        }
    }
}


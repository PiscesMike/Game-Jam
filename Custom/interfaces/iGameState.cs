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
    interface iGameState
    {
        void Initialize(ContentManager content);
        void LoadContent();
        void Update(GameTime gameTime);
        void Render(SpriteBatch spriteBatch);
        bool StateChange();
        string GetStateName();
    }
}

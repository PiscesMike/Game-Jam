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
    class Background
    {
        List<Star> Stars = new List<Star>();
        static Random Random;

        public Background(ContentManager content)
        {
            Random = new Random();
            for (int i = 0; i < 100; i++) Stars.Add(new Star(content, Random));
        }

        public void Update()
        {
            foreach (Star thisStar in Stars)
                thisStar.Update();
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (Star thisStar in Stars)
                thisStar.Render(spriteBatch);
        }

    }
}

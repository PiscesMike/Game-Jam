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
    class EnemiesLevelTwo:iEnemyCollection
    {
        List<Enemy> Enemies = new List<Enemy>();

        public EnemiesLevelTwo(ContentManager content)
        {
            Enemies.Add(new Enemy(content, new Vector2(300, 300), new Vector2(1, 1), "Ship_07", new EnemyTypeOneController(new Vector2(300, 300), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(400, 300), new Vector2(-1, -1), "Ship_08", new EnemyTypeOneController(new Vector2(400, 300), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(600, 300), new Vector2(1, 1), "Ship_09", new EnemyTypeOneController(new Vector2(600, 300), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(700, 300), new Vector2(-1, -1), "Ship_10", new EnemyTypeOneController(new Vector2(700, 300), new Vector2(1, 1))));

            Enemies.Add(new Enemy(content, new Vector2(300, 400), new Vector2(1, 1), "Ship_07", new EnemyTypeOneController(new Vector2(300, 400), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(400, 400), new Vector2(-1, -1), "Ship_08", new EnemyTypeOneController(new Vector2(400, 400), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(600, 400), new Vector2(1, 1), "Ship_09", new EnemyTypeOneController(new Vector2(600, 400), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(700, 400), new Vector2(-1, -1), "Ship_10", new EnemyTypeOneController(new Vector2(700, 400), new Vector2(1, 1))));

            Enemies.Add(new Enemy(content, new Vector2(300, 500), new Vector2(1, 1), "Ship_07", new EnemyTypeOneController(new Vector2(300, 500), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(400, 500), new Vector2(-1, -1), "Ship_08", new EnemyTypeOneController(new Vector2(400, 500), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(600, 500), new Vector2(1, 1), "Ship_09", new EnemyTypeOneController(new Vector2(600, 500), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(700, 500), new Vector2(-1, -1), "Ship_10", new EnemyTypeOneController(new Vector2(700, 500), new Vector2(1, 1))));

            Enemies.Add(new Enemy(content, new Vector2(900, 300), new Vector2(1, 1), "Ship_07", new EnemyTypeOneController(new Vector2(300, 300), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1000, 300), new Vector2(-1, -1), "Ship_08", new EnemyTypeOneController(new Vector2(400, 300), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1100, 300), new Vector2(1, 1), "Ship_09", new EnemyTypeOneController(new Vector2(600, 300), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1200, 300), new Vector2(-1, -1), "Ship_10", new EnemyTypeOneController(new Vector2(700, 300), new Vector2(1, 1))));

            Enemies.Add(new Enemy(content, new Vector2(900, 400), new Vector2(1, 1), "Ship_07", new EnemyTypeOneController(new Vector2(300, 400), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1000, 400), new Vector2(-1, -1), "Ship_08", new EnemyTypeOneController(new Vector2(400, 400), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1100, 400), new Vector2(1, 1), "Ship_09", new EnemyTypeOneController(new Vector2(600, 400), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1200, 400), new Vector2(-1, -1), "Ship_10", new EnemyTypeOneController(new Vector2(700, 400), new Vector2(1, 1))));

            Enemies.Add(new Enemy(content, new Vector2(900, 500), new Vector2(1, 1), "Ship_07", new EnemyTypeOneController(new Vector2(300, 500), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1000, 500), new Vector2(-1, -1), "Ship_08", new EnemyTypeOneController(new Vector2(400, 500), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1100, 500), new Vector2(1, 1), "Ship_09", new EnemyTypeOneController(new Vector2(600, 500), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1200, 500), new Vector2(-1, -1), "Ship_10", new EnemyTypeOneController(new Vector2(700, 500), new Vector2(1, 1))));


            Enemies.Add(new Enemy(content, new Vector2(1300, 300), new Vector2(1, 1), "Ship_07", new EnemyTypeOneController(new Vector2(1300, 300), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1400, 300), new Vector2(-1, -1), "Ship_08", new EnemyTypeOneController(new Vector2(1400, 300), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1600, 300), new Vector2(1, 1), "Ship_09", new EnemyTypeOneController(new Vector2(1600, 300), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1700, 300), new Vector2(-1, -1), "Ship_10", new EnemyTypeOneController(new Vector2(1700, 300), new Vector2(1, 1))));

            Enemies.Add(new Enemy(content, new Vector2(1300, 400), new Vector2(1, 1), "Ship_07", new EnemyTypeOneController(new Vector2(1300, 400), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1400, 400), new Vector2(-1, -1), "Ship_08", new EnemyTypeOneController(new Vector2(1400, 400), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1600, 400), new Vector2(1, 1), "Ship_09", new EnemyTypeOneController(new Vector2(1600, 400), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1700, 400), new Vector2(-1, -1), "Ship_10", new EnemyTypeOneController(new Vector2(1700, 400), new Vector2(1, 1))));

            Enemies.Add(new Enemy(content, new Vector2(1300, 500), new Vector2(1, 1), "Ship_07", new EnemyTypeOneController(new Vector2(1300, 500), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1400, 500), new Vector2(-1, -1), "Ship_08", new EnemyTypeOneController(new Vector2(1400, 500), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1600, 500), new Vector2(1, 1), "Ship_09", new EnemyTypeOneController(new Vector2(1600, 500), new Vector2(1, 1))));
            Enemies.Add(new Enemy(content, new Vector2(1700, 500), new Vector2(-1, -1), "Ship_10", new EnemyTypeOneController(new Vector2(1700, 500), new Vector2(1, 1))));

            /*Enemies.Add(new Enemy(content, new Vector2(450, 300), new Vector2(1, 1), "Enemy2", new EnemyTypeTwoController(new Vector2(450, 300), new Vector2(4, 0))));
            Enemies.Add(new Enemy(content, new Vector2(800, 300), new Vector2(-1, -1), "Enemy2", new EnemyTypeTwoController(new Vector2(800, 300), new Vector2(4, 0))));

            Enemies.Add(new Enemy(content, new Vector2(450, 300), new Vector2(1, 1), "Enemy2", new EnemyTypeThreeController(new Vector2(1050, 300), new Vector2(4, 0))));
            Enemies.Add(new Enemy(content, new Vector2(800, 300), new Vector2(-1, -1), "Enemy2", new EnemyTypeThreeController(new Vector2(1200, 300), new Vector2(4, 0))));*/
        }

        public List<Enemy> GetEnemies()
        {
            return Enemies;
        }
    }
}

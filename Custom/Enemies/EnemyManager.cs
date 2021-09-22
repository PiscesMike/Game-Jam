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
    class EnemyManager
    {
        List<Enemy> Enemies = new List<Enemy>();

        public EnemyManager(List<Enemy> enemies)
        {
            Enemies = enemies;
        }

        public void Update(List<iProjectile> shotsFired)
        {
            foreach (Enemy thisEnemy in Enemies) thisEnemy.Update(shotsFired);

            
            Enemies.RemoveAll(x => x.isAlive == false);
            shotsFired.RemoveAll(x => x.IsAlive() == false);
        }

        public List<Enemy> GetEnemies()
        {
            return Enemies;
        }

        public void ClearEnemies()
        {
            Enemies.Clear();
        }

        public void SetEnemies(List<Enemy> enemies)
        {
            Enemies = enemies;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (Enemy thisEnemy in Enemies) thisEnemy.Render(spriteBatch);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class EnemyHandler
    {
        Random random = new Random();

        private List<Enemy> enemies = new List<Enemy>();
        private Texture2D texture;

        public List<Enemy> Enemies { get => enemies; set => enemies = value; }

        public EnemyHandler(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Update();
            }

            CheckIfOutside();
            RemoveEnemies();
        }
        public void Spawn()
        {
            int spawnrate = random.Next(10);
            if (spawnrate == 0)
            {
                //Get a random position over the screen
                int positionX = random.Next(Game1.WindowWidth);

                //Add the enemy
                enemies.Add(new Enemy(texture, 80, 10, positionX));
            }
        }
        private void CheckIfOutside()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.Hitbox.Y >= Game1.WindowHeight + 10)
                    enemy.Alive = false;
            }
        }
        private void RemoveEnemies()
        {
            List<Enemy> tempEnemies = new List<Enemy>();

            foreach (Enemy enemy in enemies)
            {
                if (enemy.Alive)
                    tempEnemies.Add(enemy);
            }

            enemies = tempEnemies;
        }
    }
}

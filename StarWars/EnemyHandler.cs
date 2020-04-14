using System;
using System.Collections.Generic;
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

            CheckHitpoints();
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
                enemies.Add(new Enemy(texture, 80, 64, 10, positionX, 1));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the lasers
            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);
        }
        private void CheckHitpoints()
        {
            //Check if the enemy has less than 1 hitpoint and if so mark is as not alive
            foreach(Enemy enemy in enemies)
            {
                if (enemy.Hitpoints <= 0)
                    enemy.Alive = false;
            }
        }
        private void CheckIfOutside()
        {
            //Set the enemy alive state to false if the enemy is outside of the screen
            foreach (Enemy enemy in enemies)
            {
                if (enemy.Hitbox.Y >= Game1.WindowHeight + 10)
                    enemy.Alive = false;
            }
        }
        private void RemoveEnemies()
        {
            //A temporary list to fill with enemies
            List<Enemy> tempEnemies = new List<Enemy>();

            //If the enemy is alive, add them to the temp list
            foreach (Enemy enemy in enemies)
            {
                if (enemy.Alive)
                    tempEnemies.Add(enemy);
            }
            //Overwrite the enemies list with the temp list
            enemies = tempEnemies;
        }
    }
}

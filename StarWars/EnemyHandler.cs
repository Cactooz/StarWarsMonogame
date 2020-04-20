using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class EnemyHandler
    {
        Random random = new Random();

        //Add a stopwatch timer that will keep track of time
        Stopwatch devastatorTimer = Stopwatch.StartNew();
        Stopwatch advancedTimer = Stopwatch.StartNew();

        private List<Enemy> enemies = new List<Enemy>();
        private Texture2D tieFighterTexture, devastatorTexture, bomberTexture, interceptorTexture, advancedTexture;

        public List<Enemy> Enemies { get => enemies; set => enemies = value; }

        public EnemyHandler(Texture2D tieFighterTexture, Texture2D devastatorTexture, Texture2D bomberTexture, Texture2D interceptorTexture, Texture2D advancedTexture)
        {
            //Add the textures for all enemies
            this.tieFighterTexture = tieFighterTexture;
            this.devastatorTexture = devastatorTexture;
            this.bomberTexture = bomberTexture;
            this.interceptorTexture = interceptorTexture;
            this.advancedTexture = advancedTexture;

            //Start stopwatches
            devastatorTimer.Start();
            advancedTimer.Start();
        }
        public void Update()
        {
            //Update the enemies
            foreach (Enemy enemy in enemies)
                enemy.Update();

            CheckHitpoints();
            CheckIfOutside();
            RemoveEnemies();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the lasers
            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);
        }
        public void Spawn()
        {
            //Spawn normal enemies
            //Layout: texture, spawnAmount, hitBoxX, hitBoxY, speed, lives
            SpawnNormal(tieFighterTexture, 15, 80, 64, 7.5f, 1);
            SpawnNormal(bomberTexture, 50, 90, 95, 4f, 5);
            SpawnNormal(interceptorTexture, 60, 70, 85, 10f, 3);

            //Spawn boss enemies (that must die)
            //Layout: texture, timer, spawnTime, hitBoxX, hitBoxY, speed, lives
            SpawnBoss(devastatorTexture, devastatorTimer, 35, 288, 480, 0.5f, 30);
            SpawnBoss(advancedTexture, advancedTimer, 10, 85, 69, 5f, 5);
        }
        private void SpawnNormal(Texture2D texture, int spawnAmount, int hitBoxX, int hitBoxY, float speed, int lives)
        {
            //Spawns normal enemies
            int spawnrate = random.Next(spawnAmount);
            if (spawnrate == 0)
            {
                //Get a random position over the screen
                int positionX = random.Next(Game1.WindowWidth - hitBoxX);

                //Add the enemy
                enemies.Add(new Enemy(texture, hitBoxX, hitBoxY, speed, positionX, lives, false));
            }
        }
        private void SpawnBoss(Texture2D texture, Stopwatch timer, int spawnTime, int hitBoxX, int hitBoxY, float speed, int lives)
        {
            spawnTime = random.Next(spawnTime - 5, spawnTime + 5);
            //Spawns the boss enemies
            if (timer.Elapsed.Seconds >= spawnTime)
            {
                //Get a random position over the screen
                int positionX = random.Next(Game1.WindowWidth - hitBoxX);

                enemies.Add(new Enemy(texture, hitBoxX, hitBoxY, speed, positionX, lives, true));
                timer.Restart();
            }
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
                if (enemy.Hitbox.Y >= Game1.WindowHeight + 10 + enemy.Hitbox.Y && !enemy.MustDie)
                    enemy.Alive = false;
                else if (enemy.Hitbox.Y >= Game1.WindowHeight + 10 + enemy.Hitbox.Y && enemy.MustDie)
                {
                    //TODO: add game over scene when a mush die enemy goes outside of the screen
                    enemy.Alive = false;
                }
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

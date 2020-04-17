using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace StarWars
{
    class EnemyHandler
    {
        Random random = new Random();

        //Add a stopwatch timer that will keep track of time
        Stopwatch timer = Stopwatch.StartNew();

        private List<Enemy> enemies = new List<Enemy>();
        private Texture2D tieFighterTexture, devastatorTexture, bomberTexture, interceptorTexture;

        public List<Enemy> Enemies { get => enemies; set => enemies = value; }

        public EnemyHandler(Texture2D tieFighterTexture, Texture2D devastatorTexture, Texture2D bomberTexture, Texture2D interceptorTexture)
        {
            //Add the textures for all enemies
            this.tieFighterTexture = tieFighterTexture;
            this.devastatorTexture = devastatorTexture;
            this.bomberTexture = bomberTexture;
            this.interceptorTexture = interceptorTexture;

            //Start stopwatch
            timer.Start();
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
            SpawnTieFighter();
            SpawnBomber();
            SpawnInterceptor();
            SpawnDevastator();
        }
        private void SpawnTieFighter()
        {
            //Spawns tie fighters
            int spawnrate = random.Next(20);
            if (spawnrate == 0)
            {
                //Get a random position over the screen
                int positionX = random.Next(Game1.WindowWidth - 80);

                //Add the enemy
                enemies.Add(new Enemy(tieFighterTexture, 80, 64, 7.5f, positionX, 1, false));
            }
        }
        private void SpawnBomber()
        {
            //Spawns bomber
            int spawnrate = random.Next(50);
            if (spawnrate == 0)
            {
                //Get a random position over the screen
                int positionX = random.Next(Game1.WindowWidth - 80);

                //Add the enemy
                enemies.Add(new Enemy(bomberTexture, 90, 85, 4f, positionX, 5, false));
            }
        }
        private void SpawnInterceptor()
        {
            //Spawns interceptor
            int spawnrate = random.Next(50);
            if (spawnrate == 0)
            {
                //Get a random position over the screen
                int positionX = random.Next(Game1.WindowWidth - 78);

                //Add the enemy
                enemies.Add(new Enemy(interceptorTexture, 70, 85, 12f, positionX, 3, false));
            }
        }
        private void SpawnDevastator()
        {
            //Spawns devastator
            int spawntime = 10;
            if (timer.Elapsed.Seconds >= spawntime)
            {
                //Get a random position over the screen
                int positionX = random.Next(Game1.WindowWidth - 288);

                enemies.Add(new Enemy(devastatorTexture, 288, 480, 0.5f, positionX, 30, true));
                timer.Reset();
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

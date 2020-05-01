using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class PowerupHandler
    {
        private Random random = new Random();

        private Texture2D texture4wings, textureLives;
        private float speed = 5f;
        private int hitboxX = 75;
        private int hitboxY = 75;

        //Add a stopwatch timer that will keep track of time
        private Stopwatch spawnTimer = Stopwatch.StartNew();

        //List cotaining all powerups
        private List<Powerup> powerups = new List<Powerup>();

        /// <summary>
        /// List containing all powerups
        /// </summary>
        public List<Powerup> Powerups { get => powerups; }

        /// <summary>
        /// Constructor for PowerupHandler
        /// </summary>
        /// <param name="texture4wings">Texture for the <c>Powerup</c> where the xwing gets 4 wings</param>
        /// <param name="textureLives">Texture for the <c>Powerup</c> where you get extra lives</param>
        public PowerupHandler(Texture2D texture4wings, Texture2D textureLives)
        {
            this.texture4wings = texture4wings;
            this.textureLives = textureLives;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        public void Update()
        {
            Spawn();

            //Update the powerups
            foreach (Powerup powerup in powerups)
                powerup.Update();

            CheckIfOutside();
            RemovePowerups();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Powerup powerup in powerups)
                powerup.Draw(spriteBatch);
        }

        /// <summary>
        /// Reseting the <c>powerupHandler</c>, so the game can be played again
        /// </summary>
        public void Reset()
        {
            //Restart the spawntimer
            spawnTimer.Restart();

            //Empty the powerups list containing all powerups
            powerups.Clear();
        }

        /// <summary>
        /// Spawning powerups
        /// </summary>
        private void Spawn()
        {
            int spawnTime = random.Next(10, 20);
            if (spawnTimer.Elapsed.Seconds >= spawnTime)
            {
                int powerupType = random.Next(2);
                int positionX = random.Next(Game1.WindowWidth - hitboxX);
                if (powerupType == 0)
                    powerups.Add(new Powerup(texture4wings, hitboxX, hitboxY, speed, positionX, powerupType));
                else
                    powerups.Add(new Powerup(textureLives, hitboxX, hitboxY, speed, positionX, powerupType));
                spawnTimer.Restart();
            }
        }

        /// <summary>
        /// Checks if a powerup is below the window, if so mark is as no longer "alive"
        /// </summary>
        private void CheckIfOutside()
        {
            //Set the powerup alive state to false if the enemy is outside of the screen
            foreach (Powerup powerup in powerups)
            {
                if (powerup.Hitbox.Y >= Game1.WindowHeight + 10 + powerup.Hitbox.Y)
                {
                    powerup.Alive = false;
                }
            }
        }

        /// <summary>
        /// Removing powerups that isnt alive
        /// </summary>
        private void RemovePowerups()
        {
            //A temporary list to fill with powerups that is "alive"
            List<Powerup> tempPowerups = new List<Powerup>();

            //If the powerup is "alive", add them to the temp list
            foreach (Powerup powerup in powerups)
            {
                if (powerup.Alive)
                    tempPowerups.Add(powerup);
            }
            //Overwrite the powerups list with the temp list
            powerups = tempPowerups;
        }
    }
}

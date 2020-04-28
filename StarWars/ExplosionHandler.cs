using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StarWars.Content
{
    class ExplosionHandler
    {
        private Random random = new Random();

        private Texture2D texture1, texture2;
        private int rows, columns;

        //List containing all expolosions
        private List<Explosion> explosions = new List<Explosion>();

        /// <summary>
        /// Constructor for <c>ExplosionHandler</c>
        /// </summary>
        /// <param name="texture1">First explosion texture</param>
        /// <param name="texture2">Second explosion texture</param>
        /// <param name="rows">Animation rows of the textures</param>
        /// <param name="columns">Animation columns of the textures</param>
        public ExplosionHandler(Texture2D texture1, Texture2D texture2, int rows, int columns)
        {
            this.texture1 = texture1;
            this.texture2 = texture2;
            this.rows = rows;
            this.columns = columns;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        public void Update()
        { 
            foreach (Explosion explosion in explosions)
                explosion.Update();

            RemoveExplosion();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Explosion explosion in explosions)
                explosion.Draw(spriteBatch);
        }

        /// <summary>
        /// Adds a explosion, randomizing between teo textures
        /// </summary>
        /// <param name="position">The position of the explosion</param>
        public void AddExplosion(Vector2 position)
        {
            int textureNumber = random.Next(1, 3);
            if (textureNumber == 1)
                explosions.Add(new Explosion(texture1, 15, 15, position, rows, columns));
            else
                explosions.Add(new Explosion(texture2, 15, 15, position, rows, columns));
        }

        /// <summary>
        /// Removes the explosion when its done animating
        /// </summary>
        private void RemoveExplosion()
        {
            //A temporary list to fill with explosions
            List<Explosion> tempExplosions = new List<Explosion>();

            //If the explosions is still animating, add them to the temp list
            foreach (Explosion explosion in explosions)
            {
                if (explosion.IsAnimating)
                    tempExplosions.Add(explosion);
            }
            //Overwrite the explosions list with the temp list
            explosions = tempExplosions;
        }
    }
}

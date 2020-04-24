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

        public ExplosionHandler(Texture2D texture1, Texture2D texture2, int rows, int columns)
        {
            this.texture1 = texture1;
            this.texture2 = texture2;
            this.rows = rows;
            this.columns = columns;
        }

        public void Update()
        { 
            foreach (Explosion explosion in explosions)
                explosion.Update();

            RemoveExplosion();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            foreach (Explosion explosion in explosions)
                explosion.Draw(spriteBatch);
        }

        public void AddExplosion(Vector2 position)
        {
            int textureNumber = random.Next(1, 3);
            if (textureNumber == 1)
                explosions.Add(new Explosion(texture1, 15, 15, position, rows, columns));
            else
                explosions.Add(new Explosion(texture2, 15, 15, position, rows, columns));
        }
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

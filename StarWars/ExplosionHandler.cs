using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StarWars.Content
{
    class ExplosionHandler
    {
        private Texture2D texture;

        private int rows, columns;

        private List<Explosion> explosions = new List<Explosion>();

        public ExplosionHandler(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
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
            explosions.Add(new Explosion(texture, 15, 15, position, rows, columns));
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

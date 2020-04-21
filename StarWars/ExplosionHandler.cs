using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StarWars.Content
{
    class ExplosionHandler
    {
        private Texture2D texture;
        private Explosion explosion;
        private Vector2 position;
        private int rows, columns, currentFrame, totalFrames;

        private List<Explosion> explosions = new List<Explosion>();

        public ExplosionHandler(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            totalFrames = rows * columns;
        }

        public void Update()
        {
            AddExplosion();

            foreach (Explosion explosion in explosions)
                explosion.Update();

            RemoveExplosion();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = currentFrame / columns;
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }

        private void AddExplosion()
        {
            explosions.Add(new Explosion(texture, 15, 15));
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

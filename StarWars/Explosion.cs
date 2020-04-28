using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StarWars
{
    class Explosion:GameObject
    {
        private int rows, columns, currentFrame = 0, totalFrames;
        private bool isAnimating = true;

        /// <summary>
        /// Check if the <c>explosion</c> is still animating
        /// </summary>
        public bool IsAnimating { get => isAnimating; }

        /// <summary>
        /// Constructor for <c>Explosion</c>
        /// </summary>
        /// <param name="texture">The texture of the <c>explosion</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        /// <param name="position">The position of the <c>explosion</c></param>
        /// <param name="rows">Animation rows of the texture</param>
        /// <param name="columns">Animation columns of the texture</param>
        public Explosion(Texture2D texture, int hitboxX, int hitboxY, Vector2 position, int rows, int columns):base(texture, hitboxX, hitboxY)
        {
            Position = position;

            this.columns = columns;
            this.rows = rows;
            totalFrames = rows * columns;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        public override void Update()
        {
            currentFrame++;

            CheckCompletion();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// Animates the texture using 8 columns and 8 rows
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            int blockWidth = texture.Width / columns;
            int blockHeight = texture.Height / rows;
            int blockRow = currentFrame / columns;
            int blockColumn = currentFrame % columns;
            int positionX = Convert.ToInt32(position.X) - (blockWidth / 2);
            int positionY = Convert.ToInt32(position.Y) - (blockHeight / 2);

            Rectangle sourceRectangle = new Rectangle(blockWidth * blockColumn, blockHeight * blockRow, blockWidth, blockHeight);
            Rectangle destinationRectangle = new Rectangle(positionX, positionY, blockWidth, blockHeight);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        /// <summary>
        /// Checks if the <c>explosion</c> is done animating
        /// </summary>
        private void CheckCompletion()
        {
            if (currentFrame >= totalFrames)
                isAnimating = false;
        }
    }
}

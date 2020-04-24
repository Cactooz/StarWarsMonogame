using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StarWars
{
    class Explosion:GameObject
    {
        private int rows, columns, currentFrame = 0, totalFrames;
        private bool isAnimating = true;

        public bool IsAnimating { get => isAnimating; }
        public int CurrentFram { get => currentFrame; }

        public Explosion(Texture2D texture, int hitboxX, int hitboxY, Vector2 position, int rows, int columns):base(texture, hitboxX, hitboxY)
        {
            Position = position;

            this.columns = columns;
            this.rows = rows;
            totalFrames = rows * columns;
        }

        public override void Update()
        {
            currentFrame++;

            CheckCompletion();
        }
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
        private void CheckCompletion()
        {
            if (currentFrame >= totalFrames)
                isAnimating = false;
        }
    }
}

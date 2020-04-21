using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Laser:Entity
    {
        /// <summary>
        /// Constructor for <c>Laser</c>
        /// </summary>
        /// <param name="texture">Texture of the <c>laser</c></param>
        /// <param name="position">Position of the <c>laser</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        /// <param name="speed">Movement speed</param>
        public Laser(Texture2D texture, Vector2 position, int hitboxX, int hitboxY, float speed):base(texture, hitboxX, hitboxY, speed)
        {
            //Set the position of the laser
            Position = position;

            //Set the hitbox position
            hitbox.Width = hitboxX;
            hitbox.Height = hitboxY;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        public override void Update()
        {
            Move();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw the laser with red color overlay
            spriteBatch.Draw(texture, hitbox, Color.Red);
        }

        /// <summary>
        /// Moves the laser upwards with the movement speed of <c>speed</c>
        /// </summary>
        private void Move()
        {
            //Move the lasers by its speed on the Y axis
            position = new Vector2(position.X, position.Y - speed);

            //Set the hitbox to the position so they match
            hitbox.Location = position.ToPoint();
        }
    }
}

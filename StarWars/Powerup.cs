using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StarWars
{
    class Powerup:Entity
    {
        private int powerupType;

        /// <summary>
        /// The type of the <c>powerup</c>
        /// </summary>
        public int PowerupType { get => powerupType; }

        /// <summary>
        /// Constructor for <c>Powerup</c>
        /// </summary>
        /// <param name="texture">Texture of the <c>powerup</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        /// <param name="speed">Movement speed</param>
        /// <param name="positionX">Start X position</param>
        /// <param name="powerupType">The type of <c>powerup</c></param>
        public Powerup(Texture2D texture, int hitboxX, int hitboxY, float speed, int positionX, int powerupType):base(texture, hitboxX, hitboxY, speed)
        {
            //Set the position of the powerup
            position.X = positionX;
            position.Y = -50 - hitboxY;
            this.powerupType = powerupType + 1; //+1 since default state is 0
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
        /// Moves the <c>powerup</c> downwards with the movement speed of <c>speed</c>
        /// </summary>
        private void Move()
        {
            //Move the powerup downwards by its speed on the Y axis
            position = new Vector2(position.X, position.Y + speed);

            //Set the hitbox location to the position
            hitbox.Location = position.ToPoint();
        }
    }
}

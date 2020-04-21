using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Enemy:Entity
    {
        private bool mustDie = false;

        /// <summary>
        /// If the <c>enemy</c> must die before it goes outside of the screen
        /// </summary>
        public bool MustDie { get => mustDie; }

        /// <summary>
        /// Constructor for <c>Enemy</c>
        /// </summary>
        /// <param name="texture">Texture of the <c>enemy</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        /// <param name="speed">Movement speed</param>
        /// <param name="positionX">Start X position</param>
        /// <param name="hitpoints">How many hitpoints the <c>enemy</c> have</param>
        /// <param name="mustDie">If the <c>enemy</c> must die before it goes outside of the screen</param>
        public Enemy(Texture2D texture, int hitboxX, int hitboxY, float speed, int positionX, int hitpoints, bool mustDie):base(texture, hitboxX, hitboxY, speed)
        {
            //Set the position of the enemy
            position.X = positionX;
            position.Y = -50 - hitboxY;

            //Hitpoints of the enemy (how many times it can be hit by lasers or the player)
            this.hitpoints = hitpoints;

            //Sets if the enemy must die before it goes outside of the screen
            this.mustDie = mustDie;
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
        /// Moves the enemy downwards with the movement speed of <c>speed</c>
        /// </summary>
        private void Move()
        {
            //Move the enemies downwards by its speed on the Y axis
            position = new Vector2(position.X, position.Y + speed);

            //Set the hitbox location to the position
            hitbox.Location = position.ToPoint();
        }
    }
}

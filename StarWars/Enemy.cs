using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Enemy:Entity
    {
        private bool mustDie = false;

        public bool MustDie { get => mustDie; }

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

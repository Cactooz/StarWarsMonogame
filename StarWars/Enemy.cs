using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Enemy:Entity
    {
        public Enemy(Texture2D texture, int hitboxX, int hitboxY, int speed, int positionX):base(texture, hitboxX, hitboxY, speed)
        {
            //Set the position of the enemy
            position.X = positionX;
            position.Y = -100;
        }

        public override void Update()
        {
            Move();
        }
        private void Move()
        {
            //Move the enemies downwards by its speed on the Y axis
            position = new Vector2(position.X, position.Y + speed);

            //Set the hitbox location to the position
            hitbox.Location = position.ToPoint();
        }
    }
}

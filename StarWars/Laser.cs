using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Laser:Entity
    {
        public Laser(Texture2D texture, Vector2 position, int hitboxX, int hitboxY, int speed):base(texture, hitboxX, hitboxY, speed)
        {
            //Set the position of the laser
            Position = position;

            //Set the hitbox position
            hitbox.Width = hitboxX;
            hitbox.Height = hitboxY;
        }

        public override void Update()
        {
            Move();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw the laser with red color overlay
            spriteBatch.Draw(texture, hitbox, Color.Red);
        }
        private void Move()
        {
            //Move the lasers by its speed on the Y axis
            position = new Vector2(position.X, position.Y - speed);

            //Set the hitbox to the position so they match
            hitbox.Location = position.ToPoint();
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Laser:Entity
    {
        public Laser(Texture2D texture, Vector2 position, int hitboxSize, int speed):base(texture, hitboxSize, speed) { }

        public override void Update()
        {
            Move();
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

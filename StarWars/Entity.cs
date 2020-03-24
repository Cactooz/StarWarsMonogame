using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace StarWars
{
    class Entity:GameObject
    {
        //Speed for the entity when it moves
        private int speed;

        //If the entity is alive or not
        private bool alive = true;

        public bool Alive { get => alive; set => alive = value; }

        public Entity(Texture2D texture, Vector2 position, int hitboxSize, int speed):base(texture, position, hitboxSize)
        {
            this.speed = speed;
        }
    }
}

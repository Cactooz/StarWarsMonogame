using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Entity:GameObject
    {
        //Speed for the entity when it moves
        protected int speed;

        //If the entity is alive or not
        protected bool alive = true;

        public bool Alive { get => alive; set => alive = value; }

        public Entity(Texture2D texture, int hitboxX, int hitboxY, int speed):base(texture, hitboxX, hitboxY)
        {
            this.speed = speed;
        }
    }
}

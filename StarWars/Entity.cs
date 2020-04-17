using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Entity:GameObject
    {
        //Speed for the entity when it moves
        protected float speed;

        //If the entity is alive or not
        protected bool alive = true;

        //The lives/amount of times a enetiy can hit another entity
        protected int hitpoints = 1;

        public bool Alive { get => alive; set => alive = value; }
        public int Hitpoints { get => hitpoints; set => hitpoints = value; }

        public Entity(Texture2D texture, int hitboxX, int hitboxY, float speed):base(texture, hitboxX, hitboxY)
        {
            //Movement speed of the entity
            this.speed = speed;
    }
    }
}

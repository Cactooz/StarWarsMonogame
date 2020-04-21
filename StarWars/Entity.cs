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

        /// <summary>
        /// If the <c>entity</c> is alive or not
        /// </summary>
        public bool Alive { get => alive; set => alive = value; }
        /// <summary>
        /// How many hitpoints the <c>entity</c> has
        /// </summary>
        public int Hitpoints { get => hitpoints; set => hitpoints = value; }

        /// <summary>
        /// Constructor for <c>entity</c>
        /// </summary>
        /// <param name="texture">Texture of the <c>entity</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        /// <param name="speed">Movement speed</param>
        public Entity(Texture2D texture, int hitboxX, int hitboxY, float speed):base(texture, hitboxX, hitboxY)
        {
            //Movement speed of the entity
            this.speed = speed;
    }
    }
}

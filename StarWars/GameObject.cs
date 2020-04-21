using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class GameObject
    {
        //Texture position and hitbox for the gameObject
        protected Texture2D texture;
        protected Vector2 position;
        protected Rectangle hitbox;

        /// <summary>
        /// Position of the <c>GameObject</c>
        /// </summary>
        public Vector2 Position { get => position; set => position = value; }
        /// <summary>
        /// Hitbox for the <c>GameObject</c>
        /// </summary>
        public Rectangle Hitbox { get => hitbox; }

        /// <summary>
        /// Constructor for <c>GameObject</c>
        /// </summary>
        /// <param name="texture">Texture of the <c>entity</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        public GameObject(Texture2D texture, int hitboxX, int hitboxY)
        {
            //Load the textures and position
            this.texture = texture;

            //Set the hitbox size
            hitbox.Size = new Point(hitboxX, hitboxY);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        public virtual void Update()
        {
            //Set the hitbox to the position
            hitbox.Location = position.ToPoint();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //Draw the gameObejct with no extra color (Color.White)
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
    }
}

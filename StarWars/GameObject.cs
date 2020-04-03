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

        public Vector2 Position { get => position; set => position = value; }
        public Rectangle Hitbox { get => hitbox; }

        public GameObject(Texture2D texture, int hitboxSize)
        {
            //Load the textures and position
            this.texture = texture;

            //Set the hitbox size
            hitbox.Size = new Point(hitboxSize, hitboxSize);
        }

        public virtual void Update()
        {
            //Set the hitbox to the position
            hitbox.Location = position.ToPoint();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //Draw the gameObejct with no extra color (Color.White)
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
    }
}

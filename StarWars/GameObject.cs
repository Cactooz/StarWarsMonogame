using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class GameObject
    {
        //Texture position and hitbox for the gameObject
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;

        public Vector2 Position { get => position; }
        public Rectangle Hitbox { get => hitbox; }

        public GameObject(Texture2D texture, Vector2 position, int hitboxSize)
        {
            //Load the textures and position
            this.texture = texture;
            this.position = position;

            //Set the hitbox size
            hitbox.Size = new Point(hitboxSize, hitboxSize);
        }

        public virtual void Update()
        {
            hitbox.Location = position.ToPoint();
        }

        public virtual void Draw()
        {
            Game1.spriteBatch.Draw(texture, hitbox, Color.White);
        }

    }
}

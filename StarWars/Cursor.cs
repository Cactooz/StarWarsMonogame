using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StarWars
{
    class Cursor:GameObject
    {
        //The current mouse state
        private MouseState mouseState;

        //Textures for the cursor
        private Texture2D textureNormal, textureClick;

        /// <summary>
        /// Constructor for Cursor
        /// </summary>
        /// <param name="texture">Normal texture for <c>cursor</c></param>
        /// <param name="textureClick">Click texture for <c>cursor</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        public Cursor(Texture2D texture, Texture2D textureClick, int hitboxX, int hitboxY):base(texture, hitboxX, hitboxY)
        {
            textureNormal = texture;
            this.textureClick = textureClick;
        }

        /// <summary>
        /// Update the cursor. Follow the mouse and check if its clicking
        /// </summary>
        public override void Update()
        {
            //Get current mousestate
            mouseState = Mouse.GetState();

            hitbox.X = mouseState.X;
            hitbox.Y = mouseState.Y;

            Click();
        }

        /// <summary>
        /// Checks if the left mouse button is clicked and changes
        /// the texture to a click texture
        /// </summary>
        private void Click()
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
                texture = textureClick;
            else
                texture = textureNormal;
        }
    }
}

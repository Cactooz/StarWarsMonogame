using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StarWars
{
    class Cursor:GameObject
    {
        //The current state of the cursor
        private CursorState cursorState;

        //Current and old state of the mouse
        private MouseState mNewState;
        private MouseState mOldState;

        //Textures for the cursor
        private Texture2D textureNormal, textureClick;

        /// <summary>
        /// Get the current <c>cursorState</c>
        /// Normal or Click
        /// </summary>
        public CursorState CursorState { get => cursorState; }

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
            mNewState = Mouse.GetState();

            hitbox.X = mNewState.X;
            hitbox.Y = mNewState.Y;

            Click();

            ChangeState();

            //Save the current mouse state as the old one
            mOldState = mNewState;
        }

        /// <summary>
        /// Checks if the left mouse button is clicked and changes
        /// the texture to a click texture
        /// </summary>
        private void Click()
        {
            if (mNewState.LeftButton == ButtonState.Pressed)
                texture = textureClick;
            else
                texture = textureNormal;
        }

        /// <summary>
        /// Change the <c>cursorState</c> to click if the left mouse button is clicked
        /// and otherwise keep it as normal. Note: this does not affect the Draw texture
        /// </summary>
        private void ChangeState()
        {
            if (mNewState.LeftButton == ButtonState.Pressed && mOldState.LeftButton != ButtonState.Pressed)
                cursorState = CursorState.Click;
            else
                cursorState = CursorState.Normal;
        }
    }
}

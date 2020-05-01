using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StarWars
{
    /// <summary>
    /// Button states, Normal, Clicked & Hover
    /// </summary>
    public enum State { Normal, Clicked, Hover }
    class Button:GameObject
    {
        //The current state of the button
        private State state;

        //Current and old state of the mouse
        private MouseState mNewState;
        private MouseState mOldState;

        //Text for the button, null by default
        private string text = null;

        //Font for the text
        private SpriteFont font;

        /// <summary>
        /// Get the current state of the button
        /// </summary>
        public State State { get => state; }

        /// <summary>
        /// Constructor for Button without text
        /// </summary>
        /// <param name="texture">Texture for the <c>button</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        /// <param name="position">The position of the <c>button</c></param>
        public Button(Texture2D texture, int hitboxX, int hitboxY, Vector2 position) : base(texture, hitboxX, hitboxY)
        {
            //Set the hitbox position to the gotten position
            hitbox.Location = position.ToPoint();
        }

        /// <summary>
        /// Constructor for Button with text
        /// </summary>
        /// <param name="texture">Texture for the <c>button</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        /// <param name="position">The position of the <c>button</c></param>
        /// <param name="text">Text that should be displayed in the middle of the <c>button</c></param>
        public Button(Texture2D texture, int hitboxX, int hitboxY, Vector2 position, string text, SpriteFont font) : base(texture, hitboxX, hitboxY)
        {
            //Set the hitbox position to the gotten position
            hitbox.Location = position.ToPoint();

            this.text = text;
            this.font = font;
        }

        /// <summary>
        /// Update the buttom. Does the mouse hover over the button and is it left clicked.
        /// </summary>
        /// <param name="mouseState">The current state of the mouse</param>
        public override void Update()
        {
            //Get current mousestate
            mNewState = Mouse.GetState();

            //Check if the mouse is inside of the button hitbox
            if (hitbox.Contains(mNewState.X, mNewState.Y))
            {
                //If the button is clicked change its state
                //Holding the button won't do anything
                if (mNewState.LeftButton == ButtonState.Pressed && mOldState.LeftButton != ButtonState.Pressed)
                    state = State.Clicked;
                else
                    state = State.Hover;
            }
            else
                state = State.Normal;

            //Save the current mouse state as the old one
            mOldState = mNewState;
        }

        /// <summary>
        /// Draw the button depending on its state
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.White);
            switch (state)
            {
                case State.Normal:
                    spriteBatch.Draw(texture, hitbox, Color.White);
                    DrawFont(spriteBatch);
                    break;
                case State.Hover:
                    spriteBatch.Draw(texture, hitbox, Color.LightGray);
                    DrawFont(spriteBatch); 
                    break;
                case State.Clicked:
                    spriteBatch.Draw(texture, hitbox, Color.Gray);
                    DrawFont(spriteBatch); 
                    break;
            }
        }

        /// <summary>
        /// Draw the text in the middle of the <c>button</c> if it has text
        /// </summary>
        private void DrawFont(SpriteBatch spriteBatch)
        {
            //If the button has text, draw it in the middle of the button
            if (text != null)
                spriteBatch.DrawString(font, text, new Vector2(Hitbox.X + (Hitbox.Width / 2) - (font.MeasureString(text).X / 2), Hitbox.Y + (Hitbox.Height / 2) - (font.MeasureString(text).Y / 2)), new Color(210, 210, 210));
        }
    }
}

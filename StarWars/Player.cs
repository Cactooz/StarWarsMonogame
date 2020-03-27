using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StarWars
{
    class Player:Entity
    {
        //Keyboard states for the player
        private KeyboardState kNewState;
        private KeyboardState kOldState;

        public Player(Texture2D texture, int hitboxSize, int speed):base(texture, hitboxSize, speed)
        {
            //Set the start position
            Position = new Vector2((Game1.WindowWidth / 2) - (Hitbox.Width / 2), Game1.WindowHeight - Hitbox.Height - 50);
        }

        public override void Update()
        {
            kNewState = Keyboard.GetState();

            Move();

            //Save the old keyboard state (to check if the input is a click) 
            kOldState = kNewState;

            //Calls the base Update method for setting the hitbox to the player position
            base.Update();
        }
        private void Move()
        {
            //Move the player right when D or right arrow is pressed
            if (kNewState.IsKeyDown(Keys.D) || kNewState.IsKeyDown(Keys.Right))
            {
                //Makes sure the player doesn't go outside of the screen
                if (Position.X < Game1.WindowWidth - Hitbox.Width)
                    position.X += speed;
            }
            //Move the player left when A or left arrow i pressed
            if (kNewState.IsKeyDown(Keys.A) || kNewState.IsKeyDown(Keys.Left))
            {
                //Makes sure the player doesn't go outside of the screen
                if (Position.X > 0)
                    position.X -= speed;
            }
        }
     }
}

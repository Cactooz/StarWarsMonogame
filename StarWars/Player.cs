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

        private Texture2D laserTexture;

        private LaserHandler laserHandler;

        public Player(Texture2D texture, int hitboxSize, int speed, Texture2D laserTexture):base(texture, hitboxSize, speed)
        {
            //Set the start position
            Position = new Vector2((Game1.WindowWidth / 2) - (Hitbox.Width / 2), Game1.WindowHeight - Hitbox.Height - 50);

            //Set the laser texture / color
            this.laserTexture = laserTexture;

            //
            laserHandler = new LaserHandler(laserTexture, this);
        }

        public override void Update()
        {
            kNewState = Keyboard.GetState();

            Move();

            Shoot();

            //Save the old keyboard state (to check if the input is a click) 
            kOldState = kNewState;
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

            //Set the hitbox to the position
            hitbox.Location = position.ToPoint();
        }
        private void Shoot()
        {
            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space))
                laserHandler.Spawn();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            laserHandler.Draw(spriteBatch);

            //Calls the base Draw method for drawing the xwing
            base.Draw(spriteBatch);
        }
     }
}

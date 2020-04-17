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

        public LaserHandler LaserHandler { get => laserHandler; }

        public Player(Texture2D texture, int hitboxX, int hitboxY, float speed, int hitpoints, Texture2D laserTexture):base(texture, hitboxX, hitboxY, speed)
        {
            //Set the start position
            Position = new Vector2((Game1.WindowWidth / 2) - (Hitbox.Width / 2), Game1.WindowHeight - Hitbox.Height - (Game1.WindowHeight * 0.05f));

            //Set the laser texture / color
            this.laserTexture = laserTexture;

            //Create the laserHandler object
            laserHandler = new LaserHandler(laserTexture, this);

            this.hitpoints = hitpoints;
        }

        public override void Update()
        {
            //Get the keyboard state of what buttons are pressed
            kNewState = Keyboard.GetState();

            Move();
            
            Shoot();

            //Tell the laserHandler to update that lasers
            laserHandler.Update();

            CheckHitpoints();

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
            //Spawn a laser (through the kaserHandler) if space is pressed, but not hold
            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space))
                laserHandler.Spawn();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw the lasers through the laserHandler
            laserHandler.Draw(spriteBatch);

            //Calls the base Draw method for drawing the xwing if it's alive
            if (alive)
                base.Draw(spriteBatch);
        }
        private void CheckHitpoints()
        {
            //Change player alive state to false if it has less than 1 hitpoints
            if (hitpoints <= 0)
                alive = false;
        }
        //TODO: Make a game over scene when the player is no longer alive
     }
}

using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StarWars
{
    class Player:Entity
    {
        private Random random = new Random();
        private LaserHandler laserHandler;

        //Keyboard states for the player
        private KeyboardState kNewState;
        private KeyboardState kOldState;

        private Texture2D laserTexture;
        //Texture for the xwing when it has both wings out
        private Texture2D texture4wings;
        private bool has4wings = false;
        private int powerupState = 0;

        //Add a stopwatch timer that will keep track of time when the powerups should be removed
        private Stopwatch powerupRemoveTimer = Stopwatch.StartNew();

        /// <summary>
        /// Set the current state of the player if it has any powerup active
        /// Default state is 0. 1 and 2 are powerups
        /// </summary>
        public int PowerupState {set => powerupState = value; }
        
        /// <summary>
        /// If the player has 4 wings or not
        /// </summary>
        public bool Has4wings { get => has4wings; }

        /// <summary>
        /// The <c>laserHanldler</c> object, managing <c>lasers</c>
        /// </summary>
        public LaserHandler LaserHandler { get => laserHandler; }

        /// <summary>
        /// Constructor for <c>Player</c>
        /// </summary>
        /// <param name="texture">Texture of the <c>player</c></param>
        /// <param name="hitboxX">Hitbox width on the X axis</param>
        /// <param name="hitboxY">Hitbox width on the Y axis</param>
        /// <param name="speed">Movement speed</param>
        /// <param name="hitpoints">How many hitpoints the <c>enemy</c> have</param>
        /// <param name="laserTexture">Texture for the <c>laser</c></param>
        public Player(Texture2D texture, Texture2D texture4wings, int hitboxX, int hitboxY, float speed, int hitpoints, Texture2D laserTexture):base(texture, hitboxX, hitboxY, speed)
        {
            //Set the start position
            Position = new Vector2((Game1.WindowWidth / 2) - (Hitbox.Width / 2), Game1.WindowHeight - Hitbox.Height - (Game1.WindowHeight * 0.05f));

            //Set the powerup texture for xwing with 4 wings
            this.texture4wings = texture4wings;

            //Set the laser texture / color
            this.laserTexture = laserTexture;

            //Create the laserHandler object
            laserHandler = new LaserHandler(laserTexture, this);

            this.hitpoints = hitpoints;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        public override void Update()
        {
            //Get the keyboard state of what buttons are pressed
            kNewState = Keyboard.GetState();

            Move();
            Shoot();

            //Tell the laserHandler to update that lasers
            laserHandler.Update();

            //Check if the powerup state has changed, if so execute the right powerup
            PowerupChecker();

            //If has4wings is true, check if the 4 wings should be removed
            if (has4wings)
                Remove4wings();

            CheckHitpoints();

            //Save the old keyboard state (to check if the input is a click) 
            kOldState = kNewState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw the lasers through the laserHandler
            laserHandler.Draw(spriteBatch);

            //Calls the base Draw method for drawing the xwing if it's alive and don't have 4 wings
            if (alive && !has4wings)
                base.Draw(spriteBatch);
            else if (alive && has4wings)
                spriteBatch.Draw(texture4wings, hitbox, Color.White);
        }

        /// <summary>
        /// Moves the player right and left with the movement speed of <c>speed</c>
        /// when A and D or Left and Right keys are pressed
        /// </summary>
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

        /// <summary>
        /// Spawn lasers with <c>laserHandler</c> when space is clicked,
        /// holding the spacebar will only spawn once
        /// </summary>
        private void Shoot()
        {
            //Spawn a laser (through the kaserHandler) if space is pressed, but not hold
            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space))
                laserHandler.Spawn();
        }

        /// <summary>
        /// Checking how many hitpoints the player has left,
        /// if it's less or equal than 0 then change to the game over scene
        /// </summary>
        private void CheckHitpoints()
        {
            //Change player alive state to false if it has less than 1 hitpoints
            if (hitpoints <= 0)
                alive = false;
            //TODO: Make a game over scene when the player is no longer alive
        }

        /// <summary>
        /// Check if <c>powerupState</c> is not normal, if not execute the needed powerup
        /// </summary>
        private void PowerupChecker()
        {
            //Check if the powerupState is not normal, if so start the powerup
            if (powerupState != 0)
            {
                //If a powerup with the state of 1 is picked up
                if (powerupState == 1)
                {
                    //Start the removal timer
                    powerupRemoveTimer.Start();

                    has4wings = true;

                    PowerupReset();
                }
                //If a powerup with the state of 2 is picked up
                else if (powerupState == 2)
                {
                    //Add a extra hitpoint
                    hitpoints++;
                    PowerupReset();
                }
            }
        }

        /// <summary>
        /// Reset the <c>powerupState</c> to normal
        /// </summary>
        private void PowerupReset()
        {
            //Set powerupState to normal
            powerupState = 0;
        }

        /// <summary>
        /// Check if the <c>powerupRemoveTimer</c> has elapsed for more than the <c>powerupTime</c>
        /// If so, set <c>has4wings</c> to false
        /// </summary>
        private void Remove4wings()
        {
            int powerupTime = random.Next(10, 15);
            if (powerupRemoveTimer.Elapsed.Seconds >= powerupTime)
            {
                //Reset the timer
                powerupRemoveTimer.Reset();

                //Remove 4 wings
                has4wings = false;
            }
        }
    }
}

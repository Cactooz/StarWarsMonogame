using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StarWars
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Class objects
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Player player;
        private EnemyHandler enemyHandler;
        private GameObject background;
        private ExplosionHandler explosionHandler;
        private PowerupHandler powerupHandler;

        //Button objects
        private Button startButton, exitButton, resumeButton, mainMenuButton;

        //Enumerations objects for the state of the game
        private GameState gameState;

        //Declare variables for window size
        private static int windowWidth;
        private static int windowHeight;

        //Set the totalPoints to start at 0 points
        private int totalPoints = 0;

        //Textures for the gameObjects
        private Texture2D xwingImg, xwingFullImg, tieFighterImg, devastatorImg, laser, backgroundImg, tieBomberImg, tieInterceptorImg, tieAdvancedImg, expolsionImg1, expolsionImg2, powerupWingsImg, powerupLivesImg, buttonImg, gameLogoImg;

        //Font for the game
        private SpriteFont scoreFont, bigFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Gamewindow size and fullscreen mode
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            //Give the window size variables their value
            windowHeight = graphics.PreferredBackBufferHeight;
            windowWidth = graphics.PreferredBackBufferWidth;
        }
        /// <summary>
        /// Get the width of the window
        /// </summary>
        public static int WindowWidth { get => windowWidth; }
        /// <summary>
        /// Get the height of the window
        /// </summary>
        public static int WindowHeight { get => windowHeight; }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content. Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Make the cursor visible
            IsMouseVisible = true;

            //Fullscreen
            graphics.IsFullScreen = false;

            //Set the game state to the main menu
            gameState = GameState.MainMenu;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load in textures for the gameObjects
            backgroundImg = Content.Load<Texture2D>("stars");
            xwingImg = Content.Load<Texture2D>("xwing");
            xwingFullImg = Content.Load<Texture2D>("xwingFull");
            tieFighterImg = Content.Load<Texture2D>("tiefighter");
            tieBomberImg = Content.Load<Texture2D>("tiebomber");
            tieInterceptorImg = Content.Load<Texture2D>("tieinterceptor");
            devastatorImg = Content.Load<Texture2D>("devastator");
            tieAdvancedImg = Content.Load<Texture2D>("tieadvanced");
            laser = Content.Load<Texture2D>("laser");
            expolsionImg1 = Content.Load<Texture2D>("explosion1");
            expolsionImg2 = Content.Load<Texture2D>("explosion2");
            powerupWingsImg = Content.Load<Texture2D>("powerup4wing");
            powerupLivesImg = Content.Load<Texture2D>("powerupHeart");
            buttonImg = Content.Load<Texture2D>("button");
            gameLogoImg = Content.Load<Texture2D>("gamelogo");

            //Creates the player
            player = new Player(xwingImg, xwingFullImg, (xwingImg.Width / 5), (xwingImg.Height / 5), 10f, 3, laser);
            //Creates enemyHandler object and sending in all enemy textures
            enemyHandler = new EnemyHandler(tieFighterImg, devastatorImg, tieBomberImg, tieInterceptorImg, tieAdvancedImg);
            //Background image that sizes to fit window size
            background = new GameObject(backgroundImg, windowWidth, windowHeight);
            //Creates explosionHandler and sending in image, column and rows
            explosionHandler = new ExplosionHandler(expolsionImg1, expolsionImg2, 8, 8);
            //Creates powerupHandler with powerup images
            powerupHandler = new PowerupHandler(powerupWingsImg, powerupLivesImg);

            //Load in fonts
            scoreFont = Content.Load<SpriteFont>("scorefont");
            bigFont = Content.Load<SpriteFont>("bigfont");

            //Start button on main menu scene
            startButton = new Button(buttonImg, 400, 200, new Vector2((windowWidth / 2) - 200, (windowHeight / 2) - 100), "play", bigFont);
            //Exit button on main menu scene
            exitButton = new Button(buttonImg, 200, 100, new Vector2(10, 10), "exit", bigFont);
            //Resume button on pause scene
            resumeButton = new Button(buttonImg, 400, 200, new Vector2((windowWidth / 2) - 200, (windowHeight / 2) - 200), "resume", bigFont);
            //Main Menu button for going to the main menu
            mainMenuButton = new Button(buttonImg, 400, 200, new Vector2((windowWidth / 2) - 200, (windowHeight / 2)), "main menu", bigFont);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Switch wich version should be updated depending on the gameState
            switch (gameState)
            {
                case GameState.MainMenu:
                    UpdateMainMenu();
                    break;
                case GameState.Game:
                    UpdateGame();
                    break;
                case GameState.Pause:
                    UpdatePauseMenu();
                    break;
                case GameState.GameOver:
                    UpdateGameOver();
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the main menu should update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private void UpdateMainMenu()
        {
            //Update the enemies
            enemyHandler.Update();

            //Update the button, if it's clicked start the game
            startButton.Update();
            if (startButton.State == State.Clicked)
            {
                //Reset the game before starting
                GameReset();

                gameState = GameState.Game;
            }

            //Update the button, if it's clicked close the game
            exitButton.Update();
            if (exitButton.State == State.Clicked)
                Exit();
        }

        /// <summary>
        /// This is called when the game should update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private void UpdateGame()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || Keyboard.GetState().IsKeyDown(Keys.P))
                gameState = GameState.Pause;

            //Update the enemies
            enemyHandler.Update();

            //Update the player
            player.Update();

            //Update the powerups
            powerupHandler.Update();

            //Update the explosions
            explosionHandler.Update();

            //Check collisions between gameobjects
            Collisions();

            //Check if the player should be killed
            KillPlayerCheck();

            if (!player.Alive)
                gameState = GameState.GameOver;
        }

        /// <summary>
        /// This is called when the pause menu should update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private void UpdatePauseMenu()
        {
            //Update the button, if it's clicked continue with the game
            resumeButton.Update();
            if (resumeButton.State == State.Clicked)
                gameState = GameState.Game;

            //Update the button, if it's clicked open the main menu
            mainMenuButton.Update();
            if (mainMenuButton.State == State.Clicked)
                gameState = GameState.MainMenu;
        }

        /// <summary>
        /// This is called when the game over menu should update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private void UpdateGameOver()
        {
            //Update the button, if it's clicked close the game
            exitButton.Update();
            if (exitButton.State == State.Clicked)
                Exit();

            //Update the button, if it's clicked open the main menu
            mainMenuButton.Update();
            if (mainMenuButton.State == State.Clicked)
                gameState = GameState.MainMenu;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Start of drawing all gameObjects on the screen
            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.Black);
            //Draw the background stars
            background.Draw(spriteBatch);

            //Switch wich version should be drawn depending on the gameState
            switch (gameState)
            {
                case GameState.MainMenu:
                    DrawMainMenu();
                    break;
                case GameState.Game:
                    DrawGame();
                    break;
                case GameState.Pause:
                    DrawPauseMenu();
                    break;
                case GameState.GameOver:
                    DrawGameOver();
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// This is called when the main menu should draw itself.
        /// </summary>
        private void DrawMainMenu()
        {
            //Draw the enemies
            enemyHandler.Draw(spriteBatch);
            
            //Draw the gamelogo in the middle of the screen
            spriteBatch.Draw(gameLogoImg, new Rectangle((windowWidth/2) - 300, 100, 600, 271), Color.White);

            //Draw the start button
            startButton.Draw(spriteBatch);

            //Draw the exit button
            exitButton.Draw(spriteBatch);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        private void DrawGame()
        {
            //Draws the powerups
            powerupHandler.Draw(spriteBatch);

            //Draw the enemies
            enemyHandler.Draw(spriteBatch);

            //Draw the xwing
            player.Draw(spriteBatch);

            //Draws the expolisions
            explosionHandler.Draw(spriteBatch);

            //Draw the score
            spriteBatch.DrawString(scoreFont, $"Score: {totalPoints}", new Vector2(10, 75), Color.White);
        }

        /// <summary>
        /// This is called when the pause menu should draw itself.
        /// </summary>
        private void DrawPauseMenu()
        {
            //Draws the powerups
            powerupHandler.Draw(spriteBatch);

            //Draw the enemies
            enemyHandler.Draw(spriteBatch);

            //Draw the xwing
            player.Draw(spriteBatch);

            //Draws the expolisions
            explosionHandler.Draw(spriteBatch);

            //Draw the score
            spriteBatch.DrawString(scoreFont, $"Score: {totalPoints}", new Vector2(10, 75), Color.White);

            //Draw the start button
            resumeButton.Draw(spriteBatch);

            //Draw the main menu button
            mainMenuButton.Draw(spriteBatch);
        }

        /// <summary>
        /// This is called when the game over menu should draw itself.
        /// </summary>
        private void DrawGameOver()
        {
            //Draw the exit button
            exitButton.Draw(spriteBatch);

            //Draw the main menu button
            mainMenuButton.Draw(spriteBatch);

            //Draw the score big
            spriteBatch.DrawString(bigFont, $"Score: {totalPoints}", new Vector2((windowWidth / 2) - (bigFont.MeasureString($"Score: {totalPoints}").X / 2), (windowHeight / 2) - (bigFont.MeasureString($"Score: {totalPoints}").Y / 2) - 100), Color.White);
        }

        /// <summary>
        /// Reseting the game so it can be played again
        /// </summary>
        private void GameReset()
        {
            enemyHandler.Reset();
            player.Reset();
            powerupHandler.Reset();
            explosionHandler.Reset();

            //Set the score back to 0
            totalPoints = 0;
        }

        /// <summary>
        /// This is checking if gameObjects are intersecting with eachother
        /// and executes actions such as removing hitpoints and marks objects as no longer alive.
        /// </summary>
        private void Collisions()
        {
            foreach (Enemy enemy in enemyHandler.Enemies)
            {
                foreach (Laser laser in player.LaserHandler.Lasers)
                {
                    //Remove lasers that hits enemies and remove the enemy that gets hit
                    if (laser.Hitbox.Intersects(enemy.Hitbox))
                    {
                        //Add as many points as the enemy has hitpoints left
                        AddPoints(enemy.Hitpoints);

                        laser.Alive = false;
                        enemy.Hitpoints--;
                        SpawnExplosions(laser.Position);
                    }
                }

                //Remove enemies that the player hits and remove player hitpoints
                //Except if the enemy must die, then remove 10 hitpoints from it and one from the player
                if (player.Hitbox.Intersects(enemy.Hitbox))
                {
                    if (!enemy.MustDie)
                    {
                        enemy.Alive = false;
                        player.Hitpoints--;
                    }
                    else
                    {
                        enemy.Hitpoints -= 10;
                        player.Hitpoints--;
                    }

                    //Spawn an explosion at the bottom middle of the enemy
                    SpawnExplosions(new Vector2(enemy.Position.X + (enemy.Hitbox.Width / 2), enemy.Position.Y + enemy.Hitbox.Height));

                    //Add netagive points to remove points from the totalpoints
                    AddPoints(-100);
                }
            }
            foreach (Powerup powerup in powerupHandler.Powerups)
            {
                //Check if the player hits a powerup
                if (player.Hitbox.Intersects(powerup.Hitbox))
                {
                    player.PowerupState = powerup.PowerupType;
                    powerup.Alive = false;

                    //Add points when a powerup is picked up
                    AddPoints(25);
                }
            }
        }

        /// <summary>
        /// Spawns one of two different explosions at the defined position
        /// </summary>
        /// <param name="position">The position where the middle of the explosion should spawn</param>
        private void SpawnExplosions(Vector2 position)
        {
            explosionHandler.AddExplosion(position);
        }

        /// <summary>
        /// Add points to the int <c>totalPoints</c> that is displayed in the top left of the screen
        /// </summary>
        /// <param name="points">Points that should be added to the <c>totalPoints</c></param>
        private void AddPoints(int points)
        {
            totalPoints += points;
        }

        /// <summary>
        /// Make the <c>player</c> no longer alive if the <c>enemyHandler</c> marks that a <c>mustDie</c>
        /// <c>enemy</c> has gone outside of the screen
        /// </summary>
        private void KillPlayerCheck()
        {
            if (enemyHandler.GameOver)
                player.Alive = false;
        }
    }
}

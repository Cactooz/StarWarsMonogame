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
        private EnemyManager enemyManager;
        private GameObject background, highscoreBackground;
        private ExplosionManager explosionManager;
        private PowerupManager powerupManager;
        private Cursor cursor;
        private TextBoxInputManager textBoxInputManager = new TextBoxInputManager();

        //Create the highscoreManager object
        private HighscoreManager highscoreManager;

        //Button objects
        private Button startButton, exitButton, resumeButton, mainMenuButton, highscoreButton, backButton;

        //Enumerations objects for the state of the game
        private GameState gameState;

        //Declare variables for window size
        private static int windowWidth;
        private static int windowHeight;

        //Set the totalPoints to start at 0 points
        private int totalPoints = 0;

        //Textures for the gameObjects
        private Texture2D xwingImg, xwingFullImg, tieFighterImg, devastatorImg, laser, backgroundImg, tieBomberImg, tieInterceptorImg, lambdaImg, expolsionImg1, expolsionImg2, powerupWingsImg, powerupLivesImg, buttonImg, gameLogoImg, cursorImg, cursorClickImg, highscoreplackImg, highscoreBackgroundImg;

        //Font for the game
        private SpriteFont scoreFont, smallFont, mediumFont, bigFont, massiveFont;

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
            //Cursor visibility
            IsMouseVisible = false;

            //Fullscreen
            graphics.IsFullScreen = true;

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
            lambdaImg = Content.Load<Texture2D>("lambdat4a");
            laser = Content.Load<Texture2D>("laser");
            expolsionImg1 = Content.Load<Texture2D>("explosion1");
            expolsionImg2 = Content.Load<Texture2D>("explosion2");
            powerupWingsImg = Content.Load<Texture2D>("powerup4wing");
            powerupLivesImg = Content.Load<Texture2D>("powerupHeart");
            buttonImg = Content.Load<Texture2D>("button");
            gameLogoImg = Content.Load<Texture2D>("gamelogo");
            cursorImg = Content.Load<Texture2D>("cursor");
            cursorClickImg = Content.Load<Texture2D>("cursorclick");
            highscoreplackImg = Content.Load<Texture2D>("highscoreplack");
            highscoreBackgroundImg = Content.Load<Texture2D>("metalplate");

            //Creates the player
            player = new Player(xwingImg, xwingFullImg, (xwingImg.Width / 5), (xwingImg.Height / 5), 10f, 3, laser);
            //Creates enemyManager object and sending in all enemy textures
            enemyManager = new EnemyManager(tieFighterImg, devastatorImg, tieBomberImg, tieInterceptorImg, lambdaImg);
            //Background image that sizes to fit window size
            background = new GameObject(backgroundImg, windowWidth, windowHeight);
            //Creates explosionManager and sending in image, column and rows
            explosionManager = new ExplosionManager(expolsionImg1, expolsionImg2, 8, 8);
            //Creates powerupManager with powerup images
            powerupManager = new PowerupManager(powerupWingsImg, powerupLivesImg);
            //The background on the highscore scene
            highscoreBackground = new GameObject(highscoreBackgroundImg, windowWidth, windowHeight);

            //Creates the cursor that follows the cursor
            cursor = new Cursor(cursorImg, cursorClickImg, 50, 50);

            //Load in fonts
            scoreFont = Content.Load<SpriteFont>("scorefont");
            smallFont = Content.Load<SpriteFont>("smallfont");
            mediumFont = Content.Load<SpriteFont>("mediumfont");
            bigFont = Content.Load<SpriteFont>("bigfont");
            massiveFont = Content.Load<SpriteFont>("massivefont");

            //Start button on main menu scene
            startButton = new Button(buttonImg, 400, 200, new Vector2((windowWidth / 2) - 200, (windowHeight / 2) - 100), "play", bigFont);
            //Exit button on main menu scene
            exitButton = new Button(buttonImg, 150, 75, new Vector2(windowWidth - 160, 10), "exit", smallFont);
            //Resume button on pause scene
            resumeButton = new Button(buttonImg, 400, 200, new Vector2((windowWidth / 2) - 200, (windowHeight / 2) - 200), "resume", bigFont);
            //Main Menu button for going to the main menu
            mainMenuButton = new Button(buttonImg, 400, 200, new Vector2((windowWidth / 2) - 200, windowHeight - 300), "main menu", mediumFont);
            //Highscore button on the main menu and game over menu
            highscoreButton = new Button(buttonImg, 300, 150, new Vector2((windowWidth / 2) - 150, windowHeight - 250), "highscores", smallFont);
            //Back button to go back to the last scene, most of the time main menu
            backButton = new Button(buttonImg, 200, 100, new Vector2(10, 10), "back", smallFont);

            //Set the highscore file name, plate background and the fonts for the highscoremanager
            highscoreManager = new HighscoreManager("higscores.lst", highscoreplackImg, smallFont, mediumFont);

            //Search for a highscore file and load in the data
            highscoreManager.SearchForFile();
            highscoreManager.ReadData();
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
                case GameState.Highscore:
                    UpdateHighscoreMenu();
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
            //Update the cursor
            cursor.Update();

            //Update the enemies
            enemyManager.Update();

            CursorCollisions();

            //Update the button, if it's clicked start the game
            startButton.Update();
            if (startButton.State == ClickableButtonState.Clicked)
            {
                //Reset the game before starting
                GameReset();

                gameState = GameState.Game;
            }

            //Update the button, if it's clicked close the game
            exitButton.Update();
            if (exitButton.State == ClickableButtonState.Clicked)
            {
                highscoreManager.SaveData();

                Exit();
            }

            //Update the button, if it's clicked open the highscore menu
            highscoreButton.Update();
            if (highscoreButton.State == ClickableButtonState.Clicked)
                gameState = GameState.Highscore;

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
            enemyManager.Update();

            //Update the player
            player.Update();

            //Update the powerups
            powerupManager.Update();

            //Update the explosions
            explosionManager.Update();

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
            //Update the cursor
            cursor.Update();

            //Update the button, if it's clicked continue with the game
            resumeButton.Update();
            if (resumeButton.State == ClickableButtonState.Clicked)
                gameState = GameState.Game;

            //Update the button, if it's clicked open the main menu
            mainMenuButton.Update();
            if (mainMenuButton.State == ClickableButtonState.Clicked)
                gameState = GameState.MainMenu;
        }

        /// <summary>
        /// This is called when the game over menu should update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private void UpdateGameOver()
        {
            //Update the cursor
            cursor.Update();

            //Get key input for writing highscore name
            textBoxInputManager.GetKeyInput();

            //Update the button, if it's clicked open the main menu
            mainMenuButton.Update();
            if (mainMenuButton.State == ClickableButtonState.Clicked)
            {
                if (highscoreManager.CheckNewHighscore(totalPoints))
                    highscoreManager.AddNewHighscore(textBoxInputManager.HighscoreName, totalPoints);

                gameState = GameState.MainMenu;
            } 
        }

        /// <summary>
        /// This is called when the highscore menu should update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private void UpdateHighscoreMenu()
        {
            //Update the cursor
            cursor.Update();

            //Update the enemies
            enemyManager.Update();

            //Update the button, if it's clicked open the main menu
            backButton.Update();
            if (backButton.State == ClickableButtonState.Clicked)
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
                case GameState.Highscore:
                    DrawHighscoreMenu();
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
            enemyManager.Draw(spriteBatch);
            
            //Draw the gamelogo in the middle of the screen
            spriteBatch.Draw(gameLogoImg, new Rectangle((windowWidth/2) - 300, 100, 600, 271), Color.White);

            //Draw the start button
            startButton.Draw(spriteBatch);

            //Draw the exit button
            exitButton.Draw(spriteBatch);

            //Draw the highscore button
            highscoreButton.Draw(spriteBatch);

            //Draw the cursor (Keep last so it's above everything)
            cursor.Draw(spriteBatch);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        private void DrawGame()
        {
            //Draws the powerups
            powerupManager.Draw(spriteBatch);

            //Draw the enemies
            enemyManager.Draw(spriteBatch);

            //Draw the xwing
            player.Draw(spriteBatch);

            //Draws the expolisions
            explosionManager.Draw(spriteBatch);

            //Draw the score
            spriteBatch.DrawString(scoreFont, $"Score: {totalPoints}", new Vector2(10, 75), Color.White);
        }

        /// <summary>
        /// This is called when the pause menu should draw itself.
        /// </summary>
        private void DrawPauseMenu()
        {
            //Draws the powerups
            powerupManager.Draw(spriteBatch);

            //Draw the enemies
            enemyManager.Draw(spriteBatch);

            //Draw the xwing
            player.Draw(spriteBatch);

            //Draws the expolisions
            explosionManager.Draw(spriteBatch);

            //Draw the score
            spriteBatch.DrawString(scoreFont, $"Score: {totalPoints}", new Vector2(10, 75), Color.White);

            //Draw the start button
            resumeButton.Draw(spriteBatch);

            //Draw the main menu button
            mainMenuButton.Draw(spriteBatch);

            //Draw the cursor (Keep last so it's above everything)
            cursor.Draw(spriteBatch);
        }

        /// <summary>
        /// This is called when the game over menu should draw itself.
        /// </summary>
        private void DrawGameOver()
        {
            //Draw the main menu button
            mainMenuButton.Draw(spriteBatch);

            //Draw if its a new top highscore
            if (highscoreManager.CheckTopNewHighscore(totalPoints))
            {
                //New Highscore at the top of the screen
                spriteBatch.DrawString(massiveFont, $"new highscore", new Vector2((windowWidth / 2) - (massiveFont.MeasureString("new highscore").X / 2), 50 + massiveFont.MeasureString("new highscore").Y), Color.White);

                //Draw the score and the points below
                spriteBatch.DrawString(mediumFont, $"your score", new Vector2((windowWidth / 2) - (mediumFont.MeasureString($"your score").X / 2), (windowHeight / 2) - (mediumFont.MeasureString($"your score").Y / 2) - 175), Color.White);
                spriteBatch.DrawString(bigFont, $"{totalPoints}", new Vector2((windowWidth / 2) - (bigFont.MeasureString($"{totalPoints}").X / 2), (windowHeight / 2) - (bigFont.MeasureString($"{totalPoints}").Y / 2) - 100), Color.White);

                //Draw "your name" over the player text input
                spriteBatch.DrawString(mediumFont, "your name", new Vector2((windowWidth / 2) - (mediumFont.MeasureString("your name").X / 2), (windowHeight / 2) - (mediumFont.MeasureString("your name").Y / 2) + 25), Color.White);
                spriteBatch.DrawString(bigFont, textBoxInputManager.HighscoreName, new Vector2((windowWidth / 2) - (bigFont.MeasureString(textBoxInputManager.HighscoreName).X / 2), (windowHeight / 2) - (bigFont.MeasureString(textBoxInputManager.HighscoreName).Y / 2) + 100), Color.White);
            }
            //Draw the highscore name input if the score is bigger then the worst stores one
            else if (highscoreManager.CheckNewHighscore(totalPoints))
            {
                //Draw the score and the points below
                spriteBatch.DrawString(mediumFont, $"your score", new Vector2((windowWidth / 2) - (mediumFont.MeasureString($"your score").X / 2), (windowHeight / 2) - (mediumFont.MeasureString($"your score").Y / 2) - 175), Color.White);
                spriteBatch.DrawString(bigFont, $"{totalPoints}", new Vector2((windowWidth / 2) - (bigFont.MeasureString($"{totalPoints}").X / 2), (windowHeight / 2) - (bigFont.MeasureString($"{totalPoints}").Y / 2) - 100), Color.White);

                //Draw "your name" over the player text input
                spriteBatch.DrawString(mediumFont, "your name", new Vector2((windowWidth / 2) - (mediumFont.MeasureString("your name").X / 2), (windowHeight / 2) - (mediumFont.MeasureString("your name").Y / 2) + 25), Color.White);
                spriteBatch.DrawString(bigFont, textBoxInputManager.HighscoreName, new Vector2((windowWidth / 2) - (bigFont.MeasureString(textBoxInputManager.HighscoreName).X / 2), (windowHeight / 2) - (bigFont.MeasureString(textBoxInputManager.HighscoreName).Y / 2) + 100), Color.White);
            }
            //Otherwise just write the score
            else
            {
                //Draw the score and the points below
                spriteBatch.DrawString(mediumFont, $"your score", new Vector2((windowWidth / 2) - (mediumFont.MeasureString($"your score").X / 2), (windowHeight / 2) - (mediumFont.MeasureString($"your score").Y / 2) - 75), Color.White);
                spriteBatch.DrawString(bigFont, $"{totalPoints}", new Vector2((windowWidth / 2) - (bigFont.MeasureString($"{totalPoints}").X / 2), (windowHeight / 2) - (bigFont.MeasureString($"{totalPoints}").Y / 2)), Color.White);
            }

            //Draw the cursor (Keep last so it's above everything)
            cursor.Draw(spriteBatch);
        }

        /// <summary>
        /// This is called when the highscore menu should draw itself.
        /// </summary>
        private void DrawHighscoreMenu()
        {
            //Draw the enemies
            enemyManager.Draw(spriteBatch);

            highscoreBackground.Draw(spriteBatch);

            //Draw the main menu button
            backButton.Draw(spriteBatch);

            //Draw the player highscore placks
            highscoreManager.Draw(spriteBatch);

            //Draw the cursor (Keep last so it's above everything)
            cursor.Draw(spriteBatch);
        }

        /// <summary>
        /// Reseting the game so it can be played again
        /// </summary>
        private void GameReset()
        {
            enemyManager.Reset();
            player.Reset();
            powerupManager.Reset();
            explosionManager.Reset();

            //Set the score back to 0
            totalPoints = 0;
        }

        /// <summary>
        /// This is checking if gameObjects are intersecting with eachother
        /// and executes actions such as removing hitpoints and marks objects as no longer alive.
        /// </summary>
        private void Collisions()
        {
            foreach (Enemy enemy in enemyManager.Enemies)
            {
                foreach (Laser laser in player.LaserManager.Lasers)
                {
                    //Remove lasers that hits enemies and remove the enemy that gets hit
                    if (laser.Hitbox.Intersects(enemy.Hitbox))
                    {
                        //Add as many points as the enemy has hitpoints left
                        AddPoints(enemy.Hitpoints);

                        laser.Alive = false;
                        enemy.Hitpoints--;
                        explosionManager.AddExplosion(laser.Position);
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
                    explosionManager.AddExplosion(new Vector2(enemy.Position.X + (enemy.Hitbox.Width / 2), enemy.Position.Y + enemy.Hitbox.Height));

                    //Add netagive points to remove points from the totalpoints
                    AddPoints(-100);
                }
            }
            foreach (Powerup powerup in powerupManager.Powerups)
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
        /// Check if the cursor is collisioning with any enemy
        /// and the cursor is clicked, if so remove the enemy
        /// </summary>
        private void CursorCollisions()
        {
            //Loop through all enemies
            foreach (Enemy enemy in enemyManager.Enemies)
            {
                //Check if the enemy and cursor intersects and the left mouse button is clicked
                if (cursor.Hitbox.Intersects(enemy.Hitbox) && cursor.CursorState == CursorState.Click)
                    //Kill and remove the enemy
                    enemy.Alive = false;
            }
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
        /// Make the <c>player</c> no longer alive if the <c>enemyManager</c> marks that a <c>mustDie</c>
        /// <c>enemy</c> has gone outside of the screen
        /// </summary>
        private void KillPlayerCheck()
        {
            if (enemyManager.GameOver)
                player.Alive = false;
        }
    }
}

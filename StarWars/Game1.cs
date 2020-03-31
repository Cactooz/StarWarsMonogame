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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Declare variables for window size
        private static int windowWidth;
        private static int windowHeight;

        //Textures for the gameObjects
        Texture2D xwingImg, tiefighterImg, redLaser;

        //Class objects
        Player player;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Gamewindow size and fullscreen mode
            graphics.PreferredBackBufferHeight = 1000/*GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height*/;
            graphics.PreferredBackBufferWidth = 300/*GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width*/;
            graphics.IsFullScreen = false;

            //Give the window size variables their value
            windowHeight = graphics.PreferredBackBufferHeight;
            windowWidth = graphics.PreferredBackBufferWidth;
        }
        public static int WindowWidth { get => windowWidth; }
        public static int WindowHeight { get => windowHeight; }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load in textures for the gameObjects
            xwingImg = Content.Load<Texture2D>("xwing");
            tiefighterImg = Content.Load<Texture2D>("tiefighter");
            redLaser = Content.Load<Texture2D>("redLaser");

            //Creates the player xwing
            player = new Player(xwingImg, 110, 10, redLaser);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Update the player
            player.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //Start of drawing all gameObjects on the screen
            spriteBatch.Begin();

            //Draw the xwing
            player.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

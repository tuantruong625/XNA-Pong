/// <summary>
/// PROG 2370 - Assignment 4 : XNA Pong
/// PJ Khamvongsa & Tuan Truong    
/// 
/// Version History
/// 
/// 4.0 / 12.11
/// - Created the classes for Ball and Sprite
/// - pseudo code for the collision
/// 
/// 4.1 / 12.20
/// - created the bat class, and input class for controls
/// - programmed the collision code
///     - tested. *Need to fix bugs *
///     
/// 4.2 / 12.26
///  - Fixed bug for collision
///  - implamented score *Need to check winner *
///  
/// 4.3 / 12.27
///  - generated random speed and direction for ball
///  - bug fixes
///  
/// 4.4 / 13.29
///  - To Do
///     - check winner
///     - sound will play when
///         ball hits paddle or top or bottom wall
///         player misses
///         game ends
///     - restart game with space bar, paddles and balls
/// </summary>

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PJTTAssignment4._4.Models;
using PJTTAssignment4._4.Sprites;
using System;
using System.Collections.Generic;


namespace PJTTAssignment4._4
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;
        public static Random Random;
        

        private Score _score;
        private List<Sprite> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Initialize new dimensions of game
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
            Random = new Random();

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

            var batTexture = Content.Load<Texture2D>("Bat");
            var ballTexture = Content.Load<Texture2D>("Ball");

            _score = new Score(Content.Load<SpriteFont>("Font"));

            _sprites = new List<Sprite>()
            {
                //new Sprite(Content.Load<Texture2D>("Background")),
                new Bat(batTexture)
                {
                    position = new Vector2(20, (ScreenHeight / 2) - (batTexture.Height / 2)),
                    input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                    }

                },
                new Bat(batTexture)
                {
                    position = new Vector2(ScreenWidth - 20 - batTexture.Width, (ScreenHeight / 2) - (batTexture.Height / 2)),
                    input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                    }

                },

                new Ball(ballTexture)
                {
                    position = new Vector2((ScreenWidth / 2) - (ballTexture.Width / 2), (ScreenHeight / 2) - (ballTexture.Height / 2)),
                    Score = _score
                }
            };
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

            foreach(var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            _score.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

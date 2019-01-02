using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShipGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ShipGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private IContainer container;
        private IGameObject[] gameObjects;

        public ShipGame()
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
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            var builder = new ContainerBuilder();

            builder
                .Register(c => new DrawService(graphics, spriteBatch))
                .As<IDrawService>();
            builder.RegisterType<Ship>().As<IGameObject>();

            this.container = builder.Build();

            this.gameObjects = this.container.Resolve<IEnumerable<IGameObject>>().ToArray();

            base.Initialize();

            foreach (var gameObject in gameObjects)
            {
                gameObject.Initialize();
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            var shipContentManager = new ContentManager(Content);

            foreach (var gameObject in gameObjects)
            {
                gameObject.LoadContent(shipContentManager);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            IGameUpdateContext gameContext = new GameUpdateContext(gameTime, Keyboard.GetState());

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(gameContext);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            IGameContext gameContext = new GameContext(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(gameContext);
            }

            base.Draw(gameTime);
        }
    }
}

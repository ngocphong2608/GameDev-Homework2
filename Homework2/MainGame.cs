using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Homework2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<VisibleGameEntity> entities;

        bool bDrag = false;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = Global.Height;
            graphics.PreferredBackBufferWidth = Global.Width;
            Content.RootDirectory = "Content";

            Global.Content = this.Content;
            this.IsMouseVisible = true;

            entities = new List<VisibleGameEntity>();
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

            // TODO: use this.Content to load your game content here
            entities.Add(new TilingMap("HeightMap", 0, 0, 64, 64));
            Global.Camera.ScaleX *= 0.25f;
            Global.Camera.ScaleY *= 0.25f;
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

            // TODO: Add your update logic here
            Global.Camera.Update(gameTime);
            Global.KeyboardHelper.Update(gameTime);
            Global.MouseHelper.Update(gameTime);

            Vector2 diff;
            if (Global.MouseHelper.IsBeginToClickLeftButton())
            {
                bDrag = true;
                bFloat = false;
            }
            else if (Global.MouseHelper.IsEndToClickLeftButton())
            {
                if (bDrag)
                {
                    bDrag = false;
                    diff = Global.MouseHelper.GetMousePositionDifference();
                    Global.Camera.Translate(diff);
                    backupDiff = diff;
                    BeginToFloat();
                }
            }
            else if (Global.MouseHelper.IsLeftButtonPressed())
            {
                if (bDrag)
                {
                    diff = Global.MouseHelper.GetMousePositionDifference();
                    Global.Camera.Translate(diff);
                }
            }
            else
            {
                if (bFloat)
                {
                    diff = V0;
                    Global.Camera.Translate(diff);
                    V0 += A;
                    if (IsLowerThanEpsilon(V0))
                        bFloat = false;
                }
            }

            for (int i = 0; i < entities.Count; i++)
                entities[i].Update(gameTime);

            base.Update(gameTime);
        }

        float epsilon = 0.01f;
        private bool IsLowerThanEpsilon(Vector2 v0)
        {
            return v0.Length() <= epsilon;
        }

        Vector2 V0, A;
        bool bFloat = false;
        float K1 = 2, K2 = 0.01f;
        Vector2 backupDiff;

        private void BeginToFloat()
        {
            V0 = K1 * backupDiff;//Global.MouseHelper.GetMousePositionDifference();
            A = -K2 * V0;
            bFloat = true;

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Global.Camera.WVP);
            for (int i = 0; i < entities.Count; i++)
                entities[i].Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

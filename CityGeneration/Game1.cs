﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CityGeneration.Util;
using CityGeneration.Entitie.Player;
using Microsoft.Xna.Framework.Content;

using CityGeneration.City.Tile;

//https://codereview.stackexchange.com/questions/138578/generate-buildings-in-city
namespace CityGeneration
{
    public class Game1 : Game
    {
        public static GameServiceContainer serviceContainer = new GameServiceContainer();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera gameCam;
        Player player;
        TileManager tm;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            serviceContainer.AddService(GraphicsDevice);
            serviceContainer.AddService(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameCam = new Camera(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            gameCam.FollowingPlayer = true;

            tm = new TileManager();

            for (byte y = 0; y < 32; y++)
                for (byte x = 0; x < 41; x++)
                    tm.AddBackgroundTile(Rand.Random(0,3), x, y);

            Texture2D pTexture = Content.Load<Texture2D>("Hyper2");
            player = new Player(Content, pTexture, Vector2.Zero, new Vector2(pTexture.Bounds.Center.X, pTexture.Bounds.Center.Y));

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            tm.Update();

            player.CurrentCamPos = gameCam.GetPosition;
            player.Update();
            gameCam.Update(player.GetPosition);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp,null,null,null, gameCam.getTransformation(GraphicsDevice));
            tm.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, gameCam.getTransformation(GraphicsDevice));
            player.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

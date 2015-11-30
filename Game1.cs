using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CommNetPong
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyboardState;
        KeyboardState prevKeyboardState;
        Ball ball;
        Player localPlayer;
        Player remotePlayer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            prevKeyboardState = Keyboard.GetState();
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //sprite1 = new Sprite(Content.Load<Texture2D>("sprite1"), new Vector2(0,0), new Vector2(47, 49), graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, sprite1Sphere, Sprite1BoundingArray, Sprite1BoundingBox);
            ball = new Ball(new Sprite(Content.Load<Texture2D>("Ball"), new Vector2(100, 100), new Vector2(7, 7), graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            localPlayer = new Player(new Sprite(Content.Load<Texture2D>("VerticalPlayer"), new Vector2(5, 240 - 16), new Vector2(6, 60), graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), true);
            remotePlayer = new Player(new Sprite(Content.Load<Texture2D>("VerticalPlayer"), new Vector2(800-5-6, 240-16), new Vector2(6, 60), graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), false);

        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            localPlayer.Update(keyboardState);
            //remotePlayer.Update();
            ball.Update(localPlayer, remotePlayer);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            spriteBatch.Draw(ball.sprite.texture, ball.sprite.position, Color.White);

            spriteBatch.Draw(localPlayer.sprite.texture, localPlayer.sprite.position, Color.White);
            spriteBatch.Draw(remotePlayer.sprite.texture, remotePlayer.sprite.position, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

using Jarsefax.Xna.MonoGameFastTrack.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InputDriver {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Vector2 imagePosition = new Vector2(300, 200);
        Vector2 menuPosition = new Vector2(600, 400);

        Texture2D image;

        IInputManager inputManager;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            inputManager = new InputManager();
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Content.RootDirectory = "Content";
            image = Content.Load<Texture2D>("player");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            inputManager.Update();

            if (inputManager.IsKeyDown(Keys.W))
                imagePosition = new Vector2(imagePosition.X, imagePosition.Y - 5);
            else if (inputManager.IsKeyDown(Keys.S))
                imagePosition = new Vector2(imagePosition.X, imagePosition.Y + 5);
            if (inputManager.IsKeyDown(Keys.A))
                imagePosition = new Vector2(imagePosition.X - 5, imagePosition.Y);
            else if (inputManager.IsKeyDown(Keys.D))
                imagePosition = new Vector2(imagePosition.X + 5, imagePosition.Y);

            if (inputManager.WasKeyPressed(Keys.Up))
                menuPosition = new Vector2(imagePosition.X, menuPosition.Y - 10);
            if (inputManager.WasKeyPressed(Keys.Down))
                menuPosition = new Vector2(imagePosition.X, menuPosition.Y + 10);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(image, imagePosition, Color.White);
            spriteBatch.Draw(image, menuPosition, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
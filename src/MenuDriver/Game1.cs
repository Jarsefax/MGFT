using Jarsefax.Xna.MonoGameFastTrack.Input;
using Jarsefax.Xna.MonoGameFastTrack.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MenuDriver {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        IInputManager inputManager;
        Menu menu;

        SpriteFont regularFont, selectedFont;


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            regularFont = Content.Load<SpriteFont>("SmallFont");
            selectedFont = Content.Load<SpriteFont>("LargeFont");

            inputManager = new InputManager();

            var test = new MenuItem(0, "Test", 2, true);
            var testar = new MenuItem(1, "Testar", 1, false);
            var testung = new MenuItem(2, "Testung", -1, false);
            var testing = new MenuItem(3, "Testing", -2, true);
            menu = new Menu(
                GraphicsDevice,
                spriteBatch,
                inputManager,
                new MenuSettings(regularFont, selectedFont, Color.White, Color.Aqua, Color.DimGray),
                test,
                new[] { test, testar, testung, testing });
        }
        
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            inputManager.Update();
            menu.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            menu.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}

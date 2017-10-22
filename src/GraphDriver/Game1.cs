using GraphDriver.Nodes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GraphDriver {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D sheet;
        SolarSystem solarSystem;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize() {
            base.Initialize();
            // TODO: Add your initialization logic here
            solarSystem = new SolarSystem(new Vector2(0, 0));

            var earth = new Planet(solarSystem, spriteBatch, sheet, new Rectangle(262, 10, 240, 240), new Vector2(-100, -100));
            solarSystem.Children.Add(earth);

            var jupiter = new Planet(solarSystem, spriteBatch, sheet, new Rectangle(178, 284, 334, 197), new Vector2(100, 100));
            solarSystem.Children.Add(jupiter);
        }
        
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Content.RootDirectory = "Content";
            sheet = Content.Load<Texture2D>("planets");
        }
        
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            solarSystem.Position += new Vector2(10, 10);
            solarSystem.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            solarSystem.Draw(gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
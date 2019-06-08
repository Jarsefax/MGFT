using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Storage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TilesDriver {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ITileMap tileMap;
        int chunkX = 0;
        int chunkY = 0;
        int x = 100;
        int y = 100;

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
            var tileSheetWidth = 2;
            var tileSheetHeight = 2;
            var tileSheet = Content.Load<Texture2D>("tiles_sheet");
            var tileWidth = tileSheet.Width / tileSheetWidth;
            var tileHeight = tileSheet.Height / tileSheetHeight;

            var provider = new TileChunkProvider(tileWidth, tileHeight, tileSheet, tileSheetWidth);
            tileMap = new TileMap(provider, chunkX, chunkY);
        }
        
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up))
                y--;
            if (keyState.IsKeyDown(Keys.Down))
                y++;
            if (keyState.IsKeyDown(Keys.Left))
                x--;
            if (keyState.IsKeyDown(Keys.Right))
                x++;

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            tileMap.Draw(gameTime, spriteBatch, x, y);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

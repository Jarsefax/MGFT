using System;
using Jarsefax.Xna.MonoGameFastTrack.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Menu {
    public class Menu : IMenu {
        private IInputManager _inputManager;

        public Func<MenuInputs> GetInput => () => GetInputs();
        public IMenuItem CurrentlyHighlightedMenuItem { get; private set; }
        public IMenuItem[] MenuItems { get; }

        public GraphicsDevice GraphicsDevice { get; }
        public SpriteBatch SpriteBatch { get; }

        public IMenuSettings Settings { get; }

        public Menu(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, IInputManager inputManagar, IMenuSettings settings, MenuItem defaultMenuItem, IMenuItem[] menuItems) {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;

            Settings = settings;

            _inputManager = inputManagar;
            CurrentlyHighlightedMenuItem = defaultMenuItem;
            MenuItems = menuItems;
        }

        private MenuInputs GetInputs() => _inputManager.GetMenuInput();

        public bool Update(GameTime gameTime) {
            var result = MenuApi.Update(this);
            if (result.GameStateChangeRequested)
                return true;
            else
                CurrentlyHighlightedMenuItem = result.HighlightedMenuItem;

            return false;
        }

        public void Draw(GameTime gameTime) => MenuApi.Draw(gameTime, this);
    }
}
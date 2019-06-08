using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.MenuItems;
using Jarsefax.Xna.MonoGameFastTrack.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates {
    public abstract class BulletMenu : BulletState {
        public BulletMenu(
                GraphicsDevice graphicsDevice, 
                SpriteFont regularFont,
                SpriteFont selectedFont,
                Color regularColor,
                Color selectedColor,
                Color unselectableColor,
                BulletInput input, 
                IBulletMenuItem[] menuItems, 
                int defaultMenuItemIndex) {
            _graphicsDevice = graphicsDevice;
            _regularFont = regularFont;
            _selectedFont = selectedFont;
            _regularColor = regularColor;
            _selectedColor = selectedColor;
            _unselectableColor = unselectableColor;

            _input = input;

            _MenuItems = menuItems;

            var defaultMenuItem = _MenuItems[defaultMenuItemIndex];
            while (defaultMenuItem.IsSelectable == false) {
                defaultMenuItemIndex++;
                defaultMenuItem = _MenuItems[defaultMenuItemIndex];
            }
            _currentlyHighlightedMenuItem = defaultMenuItem;
        }

        readonly GraphicsDevice _graphicsDevice;
        readonly SpriteFont _regularFont;
        readonly SpriteFont _selectedFont;
        readonly Color _regularColor;
        readonly Color _selectedColor;
        readonly Color _unselectableColor;

        readonly BulletInput _input;

        protected readonly IBulletMenuItem[] _MenuItems;
        IBulletMenuItem _currentlyHighlightedMenuItem;

        private static IBulletMenuItem GetPreviousMenuItem(IBulletMenuItem menuItem, IBulletMenuItem[] menuItems) {
            var currentPosition = Array.IndexOf(menuItems, menuItem);
            if (currentPosition > 0) {
                var previousMenuItem = menuItems[currentPosition - 1];
                if (previousMenuItem.IsSelectable) {
                    return previousMenuItem;
                } else {
                    var nextInLine = GetPreviousMenuItem(previousMenuItem, menuItems);
                    if (nextInLine == previousMenuItem) {
                        return menuItem;
                    } else {
                        return nextInLine;
                    }
                }
            } else
                return menuItem;
        }

        private static IBulletMenuItem GetNextMenuItem(IBulletMenuItem menuItem, IBulletMenuItem[] menuItems) {
            var currentPosition = Array.IndexOf(menuItems, menuItem);
            if (currentPosition < menuItems.Length - 1) {
                var nextMenuItem = menuItems[currentPosition + 1];
                if (nextMenuItem.IsSelectable) {
                    return nextMenuItem;
                } else {
                    var nextInLine = GetNextMenuItem(nextMenuItem, menuItems);
                    if (nextInLine == nextMenuItem) {
                        return menuItem;
                    } else {
                        return nextInLine;
                    }
                }
            } else
                return menuItem;
        }

        public override BulletState Update(GameTime gameTime) {
            switch (_input.GetMenuInput()) {
                case MenuInputs.UpPressed:
                    _currentlyHighlightedMenuItem = GetPreviousMenuItem(_currentlyHighlightedMenuItem, _MenuItems);
                    return this;
                case MenuInputs.DownPressed:
                    _currentlyHighlightedMenuItem = GetNextMenuItem(_currentlyHighlightedMenuItem, _MenuItems);
                    return this;
                case MenuInputs.Selected:
                    return _currentlyHighlightedMenuItem.DestinationState;
                case MenuInputs.Neutral:
                default:
                    return this;
            }
        }

        private static int CalculateCenter(int origin, int length, int offset) => origin + (length - offset) / 2;

        private static Vector2 CalculatePosition(SpriteFont font, string text, Rectangle safeDrawArea, float yOffset) {
            var textSize = font.MeasureString(text);
            var posX = CalculateCenter(safeDrawArea.Left, safeDrawArea.Width, (int)textSize.X);
            var posY = CalculateCenter(safeDrawArea.Top, safeDrawArea.Height, safeDrawArea.Y + (int)(yOffset * 50.0)); // TODO (rnor): replace magic number (50) with calculation from screen size

            return new Vector2(posX, posY);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {            
            foreach (var menuItem in _MenuItems) {
                if (menuItem.IsSelectable == false) {
                    var pos = CalculatePosition(_regularFont, menuItem.Text, _graphicsDevice.Viewport.TitleSafeArea, menuItem.DrawOffsetY);
                    spriteBatch.DrawString(_regularFont, menuItem.Text, pos, _unselectableColor);
                } else if (menuItem == _currentlyHighlightedMenuItem) {
                    var pos = CalculatePosition(_selectedFont, menuItem.Text, _graphicsDevice.Viewport.TitleSafeArea, menuItem.DrawOffsetY);
                    spriteBatch.DrawString(_selectedFont, menuItem.Text, pos, _selectedColor);
                } else {
                    var pos = CalculatePosition(_regularFont, menuItem.Text, _graphicsDevice.Viewport.TitleSafeArea, menuItem.DrawOffsetY);
                    spriteBatch.DrawString(_regularFont, menuItem.Text, pos, _regularColor);
                }                
            }
        }
    }
}
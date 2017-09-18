using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Menu {
    public static class MenuApi {
        private static IMenuItem GetPreviousMenuItem(IMenuItem menuItem, IMenuItem[] menuItems) {
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

        private static IMenuItem GetNextMenuItem(IMenuItem menuItem, IMenuItem[] menuItems) {
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

        public static MenuUpdateResult UpdateExplicit(Func<MenuInputs> getInput, IMenuItem currentlyHighlightedMenuItem, IMenuItem[] menuItems) {
            switch (getInput()) {
                case MenuInputs.UpPressed:
                    return new MenuUpdateResult(false, GetPreviousMenuItem(currentlyHighlightedMenuItem, menuItems));
                case MenuInputs.DownPressed:
                    return new MenuUpdateResult(false, GetNextMenuItem(currentlyHighlightedMenuItem, menuItems));
                case MenuInputs.Selected:
                    return new MenuUpdateResult(true, currentlyHighlightedMenuItem);
                default:
                case MenuInputs.Neutral:
                    return new MenuUpdateResult(false, currentlyHighlightedMenuItem);
            }
        }
        public static MenuUpdateResult Update(IMenu menu) => UpdateExplicit(menu.GetInput, menu.CurrentlyHighlightedMenuItem, menu.MenuItems);

        private static int CalculateCenter(int origin, int length, int offset) => origin + (length - offset) / 2;

        private static Vector2 CalculatePosition(SpriteFont font, string text, Rectangle safeDrawArea, int yOffset) {
            var textSize = font.MeasureString(text);
            var posX = CalculateCenter(safeDrawArea.Left, safeDrawArea.Width, (int)textSize.X);
            var posY = CalculateCenter(safeDrawArea.Top, safeDrawArea.Height, (int)safeDrawArea.Y + (yOffset * 50)); // TODO (rnor): replace magic number (50) with calculation from screen size

            return new Vector2(posX, posY);
        }

        private static void DrawExplicit(GameTime gameTime, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, IMenuItem[] menuItems, IMenuItem currentlySelectedMenuItem, IMenuSettings menuSettings) {
            graphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            foreach (var menuItem in menuItems) {
                var fontAndColor = new FontAndColor(menuItem, currentlySelectedMenuItem, menuSettings);
                var pos = CalculatePosition(fontAndColor.Font, menuItem.Text, graphicsDevice.Viewport.TitleSafeArea, menuItem.DrawOffsetY);
                spriteBatch.DrawString(fontAndColor.Font, menuItem.Text, pos, fontAndColor.Color);
            }
            spriteBatch.End();
        }
        public static void Draw(GameTime gameTime, IMenu menu) => DrawExplicit(gameTime, menu.GraphicsDevice, menu.SpriteBatch, menu.MenuItems, menu.CurrentlyHighlightedMenuItem, menu.Settings);
    }
}
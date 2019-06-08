using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.MenuItems;
using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Main.Items;
using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Main {
    public class BulletMainMenu : BulletMenu {
        public static BulletState Continue;
        public static BulletState Load;
        public static BulletState New;

        public BulletMainMenu(
            GraphicsDevice graphicsDevice,
            SpriteFont regularFont,
            SpriteFont selectedFont,
            Color regularColor,
            Color selectedColor,
            Color unselectableColor,
            BulletInput input)
            : base(
                graphicsDevice,
                regularFont,
                selectedFont,
                regularColor,
                selectedColor,
                unselectableColor,
                input,                   
                new IBulletMenuItem[] {
                    new Continue(Continue),
                    new Load(Load),
                    new New(New),
                    new Items.Settings(new BulletSettingsMenu(
                        graphicsDevice,
                        regularFont,
                        selectedFont,
                        regularColor,
                        selectedColor,
                        unselectableColor,
                        input)
                    ),
                    new Exit()
                }, 
                0) {
            foreach (var menuItem in _MenuItems) {
                var test = menuItem as Items.Settings;
                if (test != null) {
                    var settingsMenu = test.DestinationState as BulletSettingsMenu;
                    settingsMenu.SetBackDestination(this);
                }
            }
        }
    }
}
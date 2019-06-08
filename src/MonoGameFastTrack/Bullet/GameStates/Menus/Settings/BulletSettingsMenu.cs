using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.MenuItems;
using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Settings.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Settings {
    public class BulletSettingsMenu : BulletMenu {
        public static BulletState GameplaySettings;
        public static BulletState ControlsSettings;
        public static BulletState AudioSettings;
        public static BulletState VideoSettings;

        public BulletSettingsMenu(
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
                new IBulletMenuItem[] { new Gameplay(GameplaySettings), new Controls(ControlsSettings), new Audio(AudioSettings), new Video(VideoSettings), new Back() }, 
                0) { }
        
        internal void SetBackDestination(BulletState destinationState) {
            foreach (var menuItem in _MenuItems) {
                var test = menuItem as Back;
                if (test != null) {
                    test.DestinationState = destinationState;
                }
            }
        }
    }
}

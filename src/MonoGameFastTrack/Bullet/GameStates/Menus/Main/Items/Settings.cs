using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.MenuItems;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Main.Items {
    class Settings : IBulletMenuItem {
        public Settings(BulletState bulletSettingsMenu) : this(3, true, "Settings", -1, bulletSettingsMenu) { }

        public Settings(int position, bool isSelectable, string text, float drawOffsetY, BulletState destinationState) {
            Position = position;
            IsSelectable = isSelectable;
            Text = text;
            DrawOffsetY = drawOffsetY;
            DestinationState = destinationState;
        }

        public int Position { get; }
        public bool IsSelectable { get; }
        public string Text { get; }
        public float DrawOffsetY { get; }
        public BulletState DestinationState { get; }
    }
}
using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.MenuItems;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Settings.Items {
    class Audio : IBulletMenuItem {
        public Audio(BulletState destinationState) : this(2, true, "Audio", -0.5f, destinationState) { }

        public Audio(int position, bool isSelectable, string text, float drawOffsetY, BulletState destinationState) {
            Position = position;
            IsSelectable = isSelectable;
            Text = text;
            DrawOffsetY = drawOffsetY;
        }

        public int Position { get; }
        public bool IsSelectable { get; }
        public string Text { get; }
        public float DrawOffsetY { get; }
        public BulletState DestinationState { get; }
    }
}
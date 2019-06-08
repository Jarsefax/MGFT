using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.MenuItems;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Settings.Items {
    class Gameplay : IBulletMenuItem {
        public Gameplay(BulletState destinationState) : this(0, true, "Gameplay", 1.5f, destinationState) { }

        public Gameplay(int position, bool isSelectable, string text, float drawOffsetY, BulletState destinationState) {
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

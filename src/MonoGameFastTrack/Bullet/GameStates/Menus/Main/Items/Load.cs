using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.MenuItems;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Main.Items {
    class Load : IBulletMenuItem {
        // TODO: implement canLoad check
        public Load(BulletState loadingState) : this(1, false, "Load Game", 1, loadingState) { }

        public Load(int position, bool isSelectable, string text, float drawOffsetY, BulletState destinationState) {
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
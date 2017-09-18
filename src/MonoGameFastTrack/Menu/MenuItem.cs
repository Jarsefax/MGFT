namespace Jarsefax.Xna.MonoGameFastTrack.Menu {
    public class MenuItem : IMenuItem {
        public int Position { get; }
        public string Text { get; }
        public int DrawOffsetY { get; }
        public bool IsSelectable { get; }

        public MenuItem(int position, string text, int drawOffsetY, bool isSelectable) {
            Position = position;
            Text = text;
            DrawOffsetY = drawOffsetY;
            IsSelectable = isSelectable;
        }
    }
}
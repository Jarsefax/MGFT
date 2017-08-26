namespace Jarsefax.Xna.MonoGameFastTrack.Menu {
    public interface IMenuItem {
        int Position { get; }
        bool IsSelectable { get; }
        string Text { get; }
        int DrawOffsetY { get; }
        //int GameState { get; }
    }
}

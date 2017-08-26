namespace Jarsefax.Xna.MonoGameFastTrack.Menu {
    public class MenuUpdateResult {
        public bool GameStateChangeRequested { get; }
        public IMenuItem HighlightedMenuItem { get; }

        public MenuUpdateResult(bool gameStateChangeRequested, IMenuItem highlightedMenuItem) {
            GameStateChangeRequested = gameStateChangeRequested;
            HighlightedMenuItem = highlightedMenuItem;
        }
    }
}
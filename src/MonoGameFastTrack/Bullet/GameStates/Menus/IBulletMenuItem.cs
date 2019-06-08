namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.MenuItems {
    public interface IBulletMenuItem {
        int Position { get; }
        bool IsSelectable { get; }
        string Text { get; }
        float DrawOffsetY { get; }
        BulletState DestinationState { get; }
    }
}
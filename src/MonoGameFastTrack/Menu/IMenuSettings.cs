using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Menu {
    public interface IMenuSettings {
        SpriteFont RegularFont { get; }
        SpriteFont SelectedFont { get; }

        Color RegularColor { get; }
        Color SelectedColor { get; }
        Color UnselectableColor { get; }
    }
}
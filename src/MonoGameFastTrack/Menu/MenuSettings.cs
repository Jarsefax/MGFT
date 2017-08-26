using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Menu {
    public class MenuSettings : IMenuSettings {
        public SpriteFont RegularFont { get; }
        public SpriteFont SelectedFont { get; }

        public Color RegularColor { get; }
        public Color SelectedColor { get; }
        public Color UnselectableColor { get; }

        public MenuSettings(SpriteFont regularFont, SpriteFont selectedFont, Color regularColor, Color selectedColor, Color unselectableColor) {
            RegularFont = regularFont;
            SelectedFont = selectedFont;

            RegularColor = regularColor;
            SelectedColor = selectedColor;
            UnselectableColor = unselectableColor;
        }
    }
}
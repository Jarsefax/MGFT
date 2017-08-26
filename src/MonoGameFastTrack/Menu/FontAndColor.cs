using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Menu {
    public class FontAndColor {
        public SpriteFont Font { get; }
        public Color Color { get; }

        public FontAndColor(IMenuItem subjectMenuItem, IMenuItem currentlySelectedMenuItem, IMenuSettings menuSettings) {
            if (subjectMenuItem.IsSelectable == false) {
                Font = menuSettings.RegularFont;
                Color = menuSettings.UnselectableColor;
            } else if (subjectMenuItem == currentlySelectedMenuItem) {
                Font = menuSettings.SelectedFont;
                Color = menuSettings.SelectedColor;
            } else {
                Font = menuSettings.RegularFont;
                Color = menuSettings.RegularColor;
            }
        }
    }
}
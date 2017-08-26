using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Menu {
    public interface IMenu {
        GraphicsDevice GraphicsDevice { get; }
        SpriteBatch SpriteBatch { get; }

        IMenuSettings Settings { get; }

        Func<MenuInputs> GetInput { get; }
        IMenuItem CurrentlyHighlightedMenuItem { get; }
        IMenuItem[] MenuItems { get; }

        bool Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}

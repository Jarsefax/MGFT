using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Main.Items {
    class Exit : BulletState, IBulletMenuItem {
        public Exit() : this(4, true, "Exit Game", -3) { }

        public Exit(int position, bool isSelectable, string text, float drawOffsetY) {
            Position = position;
            IsSelectable = isSelectable;
            Text = text;
            DrawOffsetY = drawOffsetY;
        }

        bool shouldExit;

        public int Position { get; }
        public bool IsSelectable { get; }
        public string Text { get; }
        public float DrawOffsetY { get; }

        public BulletState DestinationState => this;

        public override BulletState Update(GameTime gameTime) {
            if (shouldExit) {
                Environment.Exit(0);
            }

            shouldExit = true; // TODO (rnor): ask for confirmation
            return this;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            // TODO (rnor): Draw confirmation
        }
    }
}
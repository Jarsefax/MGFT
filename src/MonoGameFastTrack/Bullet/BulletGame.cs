using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates;
using Jarsefax.Xna.MonoGameFastTrack.Bullet.GameStates.Menus.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet {
    public abstract class BulletGame : Game {
        protected BulletInput _Input;
        protected BulletMenu _Menu;
        protected BulletState _CurrentState;
        protected bool _PlayOnly;


        protected SpriteBatch _SpriteBatch;
        protected SpriteFont _RegularFont;
        protected SpriteFont _SelectedFont;
        protected Color _RegularColor;
        protected Color _SelectedColor;
        protected Color _UnselectableColor;

        protected override void Initialize() {
            base.Initialize();

            _Input = new BulletInput();
            if (_PlayOnly == false) {
                var menu = new BulletMainMenu(
                    GraphicsDevice,
                    _RegularFont,
                    _SelectedFont,
                    _RegularColor,
                    _SelectedColor,
                    _UnselectableColor,
                    _Input);

                _Menu = menu;
                _CurrentState = menu;
            }
        }
        
        protected override void Update(GameTime gameTime) {
            _Input.Update();
            _CurrentState = _CurrentState.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            _SpriteBatch.Begin();

            _CurrentState.Draw(gameTime, _SpriteBatch);

            _SpriteBatch.End();

            base.Draw(gameTime);
        }        
    }
}
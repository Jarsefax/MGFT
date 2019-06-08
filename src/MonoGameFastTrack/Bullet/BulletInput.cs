using Jarsefax.Xna.MonoGameFastTrack.Menu;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet {
    public class BulletInput {
        public BulletInput() {
            OldKeyboardState = Keyboard.GetState();
            NewKeyboardState = Keyboard.GetState();
        }

        public virtual void Update() {
            OldKeyboardState = NewKeyboardState;
            NewKeyboardState = Keyboard.GetState();
        }

        public KeyboardState OldKeyboardState { get; private set; }
        public KeyboardState NewKeyboardState { get; private set; }

        public bool IsKeyDown(Keys key) => NewKeyboardState.IsKeyDown(key);
        public bool WasKeyPressed(Keys key) => !OldKeyboardState.IsKeyDown(key) && NewKeyboardState.IsKeyDown(key);
        public IEnumerable<Keys> PressedKeys => NewKeyboardState.GetPressedKeys().Except(OldKeyboardState.GetPressedKeys());

        public MenuInputs GetMenuInput() {
            var up = NewKeyboardState.IsKeyDown(Keys.Up) && !OldKeyboardState.IsKeyDown(Keys.Up);
            var down = NewKeyboardState.IsKeyDown(Keys.Down) && !OldKeyboardState.IsKeyDown(Keys.Down);
            var enter = NewKeyboardState.IsKeyDown(Keys.Enter) && !OldKeyboardState.IsKeyDown(Keys.Enter);

            if (enter) {
                return MenuInputs.Selected;
            }

            if (up && !down) {
                return MenuInputs.UpPressed;
            } else if (down && !up) {
                return MenuInputs.DownPressed;
            }

            return MenuInputs.Neutral;
        }
    }
}
using System.Collections.Generic;
using Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine;
using Jarsefax.Xna.MonoGameFastTrack.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FiniteStateMachineDriver {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        IInputManager inputManager;
        IDrawableFiniteStateMachine finiteStateMachine;
        SpriteFont font;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("LargeFont");

            inputManager = new InputManager();

            var stateOne = new StateOne(inputManager, spriteBatch, font);
            var stateTwo = new StateTwo(inputManager, spriteBatch, font);
            var stateThree = new StateThree(inputManager, spriteBatch, font);
            var stateFour = new StateFour(inputManager, spriteBatch, font);
            var states = new List<IDrawableState>() { stateOne, stateTwo, stateThree, stateFour };
            finiteStateMachine = new DrawableFiniteStateMachine(states, stateOne);

            stateOne.NextOne = stateTwo;
            stateOne.NextTwo = stateThree;

            stateTwo.Next = stateThree;
            stateTwo.Previous = stateOne;

            stateThree.Next = stateFour;
            stateThree.Previous = stateOne;

            stateFour.Previous = stateThree;
        }
        
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            inputManager.Update();
            finiteStateMachine.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            finiteStateMachine.Draw(gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
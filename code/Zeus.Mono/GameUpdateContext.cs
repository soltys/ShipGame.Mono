using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ShipGame
{
    class GameUpdateContext : GameContext, IGameUpdateContext
    {
        public GameUpdateContext(GameTime gameTime, KeyboardState keyboardState) : base(gameTime)
        {
            KeyboardState = keyboardState;
        }

        public KeyboardState KeyboardState { get; }
    }
}
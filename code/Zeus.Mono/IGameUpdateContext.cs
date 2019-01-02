using Microsoft.Xna.Framework.Input;

namespace ShipGame
{
    interface IGameUpdateContext : IGameContext
    {
        KeyboardState KeyboardState { get; }
    }
}
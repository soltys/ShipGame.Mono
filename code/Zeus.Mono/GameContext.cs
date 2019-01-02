using Microsoft.Xna.Framework;

namespace ShipGame
{
    class GameContext : IGameContext
    {
        public GameTime GameTime { get; }

        public GameContext(GameTime gameTime)
        {
            GameTime = gameTime;
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShipGame
{
    public class DrawService : IDrawService
    {
        public DrawService(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            GraphicsDeviceManager = graphics;
            SpriteBatch = spriteBatch;
        }

        public GraphicsDeviceManager GraphicsDeviceManager { get; }
        public SpriteBatch SpriteBatch { get; }
    }
}
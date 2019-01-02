using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShipGame
{
    public interface IDrawService
    {
        GraphicsDeviceManager GraphicsDeviceManager { get; }
        SpriteBatch SpriteBatch { get; }
    }
}
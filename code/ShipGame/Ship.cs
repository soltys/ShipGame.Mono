using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShipGame
{
    class Ship : IGameObject
    {
        private IDrawService drawService;
        private Texture2D rect;
        private Vector2 coor;

        public Ship(IDrawService drawService)
        {
            this.drawService = drawService;
        }
        public void Initialize()
        {
            rect = new Texture2D(this.drawService.GraphicsDeviceManager.GraphicsDevice, 80, 30);

            Color[] data = new Color[80 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);

            coor = new Vector2(10, 20);
        }

        public void Destroy()
        {
        }

        public void LoadContent(IContentManager contentManager)
        {
        }

        public void Update(IGameUpdateContext context)
        {
            if (context.KeyboardState.IsKeyDown(Keys.Right))
            {
                coor = Vector2.Add(coor, new Vector2(10, 0));
            }
            if (context.KeyboardState.IsKeyDown(Keys.Left))
            {
                coor = Vector2.Add(coor, new Vector2(-10, 0));
            }

            if (context.KeyboardState.IsKeyDown(Keys.Up))
            {
                coor = Vector2.Add(coor, new Vector2(0, -10));
            }
            if (context.KeyboardState.IsKeyDown(Keys.Down))
            {
                coor = Vector2.Add(coor, new Vector2(0, 10));
            }
        }

        public void Draw(IGameContext context)
        {
            this.drawService.SpriteBatch.Begin();
            this.drawService.SpriteBatch.Draw(rect, coor, Color.White);
            this.drawService.SpriteBatch.End();
        }
    }
}

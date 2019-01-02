namespace ShipGame
{
    class ContentManager : IContentManager
    {
        private readonly Microsoft.Xna.Framework.Content.ContentManager contentManager;

        public ContentManager(Microsoft.Xna.Framework.Content.ContentManager xnaContentManager)
        {
            this.contentManager = xnaContentManager;
        }

        public T Load<T>(string assetName)
        {
            return contentManager.Load<T>(assetName);
        }
    }
}
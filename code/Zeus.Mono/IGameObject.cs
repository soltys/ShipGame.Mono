namespace ShipGame
{
    interface IGameObject
    {
        void Initialize();
        void Destroy();

        void LoadContent(IContentManager contentManager);

        void Update(IGameUpdateContext context);
        void Draw(IGameContext context);
    }
}

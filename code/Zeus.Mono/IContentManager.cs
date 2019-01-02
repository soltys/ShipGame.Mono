namespace ShipGame
{
    interface IContentManager
    {
        T Load<T>(string assetName);
    }
}
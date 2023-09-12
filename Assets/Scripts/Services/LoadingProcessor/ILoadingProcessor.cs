namespace Core.LoadingProcessor
{
    public interface ILoadingProcessor : IProcessor
    {
        float Progress { get; } 
    }
}
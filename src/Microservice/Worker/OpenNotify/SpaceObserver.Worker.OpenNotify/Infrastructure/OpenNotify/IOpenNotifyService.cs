namespace SpaceObserver.Worker.ISS.Infrastructure.OpenNotify
{
    using System.Threading.Tasks;

    public interface IOpenNotifyService
    {
        Task<string> GetLocationAsync();
    }
}
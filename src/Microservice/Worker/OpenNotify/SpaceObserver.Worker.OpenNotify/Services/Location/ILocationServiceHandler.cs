namespace SpaceObserver.Worker.ISS.Services.Location
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ILocationServiceHandler
    {
        Task GetLocationAsync(CancellationToken cancellationToken);
    }
}
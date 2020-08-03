namespace SpaceObserver.Worker.ISS.Infrastructure.OpenNotify
{
    using Dtos;
    using System.Threading.Tasks;

    public interface IOpenNotifyService
    {
        Task<LocationDto> GetIssLocationAsync();
    }
}
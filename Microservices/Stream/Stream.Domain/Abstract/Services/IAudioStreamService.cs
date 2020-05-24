using System.Threading.Tasks;

namespace Stream.Domain.Abstract.Services
{
    public interface IAudioStreamService
    {
        Task<System.IO.Stream> GetAudioStreamAsync(string videoId);
    }
}

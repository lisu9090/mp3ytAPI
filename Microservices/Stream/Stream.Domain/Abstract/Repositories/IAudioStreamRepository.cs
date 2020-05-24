using Stream.Domain.Models;

namespace Stream.Domain.Abstract.Repositories
{
    public interface IAudioStreamRepository
    {
        System.IO.Stream GetAudioStream(string url);
        AudioDescription GetAudioDescription(string url);
    }
}

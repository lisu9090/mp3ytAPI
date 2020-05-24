using Stream.Domain.Models;

namespace Stream.Domain.Abstract.Repositories
{
    public interface IAudioStreamRepository
    {
        object GetAudioStream(string url);
        AudioDescription GetAudioDescription(string url);
    }
}

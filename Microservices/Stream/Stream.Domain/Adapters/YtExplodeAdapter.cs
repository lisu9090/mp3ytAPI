using Stream.Domain.Abstract.Adapters;
using System.IO;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Stream.Domain.Adapters
{
    public class YtExplodeAdapter : IYtExplodeAdapter
    {
        private YoutubeClient ytClient = new YoutubeClient();

        public async Task<System.IO.Stream> GetAudioStreamAsync(IStreamInfo streamInfo)
        {
            return await ytClient.Videos.Streams.GetAsync(streamInfo);
        }

        public async Task<StreamManifest> GetStreamManifestAsync(string videoId)
        {
            return await ytClient.Videos.Streams.GetManifestAsync(videoId);
        }
    }
}

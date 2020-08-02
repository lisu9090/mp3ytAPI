using Jering.Javascript.NodeJS;
using Stream.Domain.Abstract.Adapters;
using Stream.Domain.Abstract.Services;
using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;

namespace Stream.Domain.Domain
{
    public class YtAudioStreamService : IAudioStreamService
    {
        private IYtExplodeAdapter _ytExplodeAdapter;

        public YtAudioStreamService(IYtExplodeAdapter ytExplodeAdapter)
        {
            _ytExplodeAdapter = ytExplodeAdapter;
        }

        public async Task<System.IO.Stream> GetAudioStreamAsync(string videoId)
        {
            var manifest = await _ytExplodeAdapter.GetStreamManifestAsync(videoId);
            var info = manifest.GetAudioOnly().WithHighestBitrate();
            
            return await _ytExplodeAdapter.GetAudioStreamAsync(info);
        }
    }
}

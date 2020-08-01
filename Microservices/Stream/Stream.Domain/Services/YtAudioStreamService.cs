using Jering.Javascript.NodeJS;
using Stream.Domain.Abstract.Repositories;
using Stream.Domain.Abstract.Services;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Stream.Domain.Domain
{
    public class YtAudioStreamService : IAudioStreamService
    {
        public async Task<System.IO.Stream> GetAudioStreamAsync(string videoId)
        {
            //todo: clean this codes

            var ytClient = new YoutubeClient();

            var streamManifest = await ytClient.Videos.Streams.GetManifestAsync(videoId);
            
            var streamInfo = streamManifest.GetAudioOnly().WithHighestBitrate();

            return await ytClient.Videos.Streams.GetAsync(streamInfo);
        }
    }
}

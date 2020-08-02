using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;

namespace Stream.Domain.Abstract.Adapters
{
    public interface IYtExplodeAdapter
    {
        Task<StreamManifest> GetStreamManifestAsync(string videoId);
        Task<System.IO.Stream> GetAudioStreamAsync(IStreamInfo streamInfo);
    }
}

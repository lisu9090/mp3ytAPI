using Stream.Domain.Abstract.Repositories;
using Stream.Domain.Abstract.Services;
using Stream.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Stream.Domain.Domain
{
    public class YtAudioStreamService : IAudioStreamService
    {
        private IAudioStreamRepository _audioStreamRepository;

        public YtAudioStreamService(IAudioStreamRepository audioStreamRepository)
        {
            _audioStreamRepository = audioStreamRepository;
        }

        public Task<System.IO.Stream> GetAudioStreamAsync(string videoId)
        {
            return new TaskFactory<System.IO.Stream>().StartNew(() => _audioStreamRepository.GetAudioStream(videoId));
        }
    }
}

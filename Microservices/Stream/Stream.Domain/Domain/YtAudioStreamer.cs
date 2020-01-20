using Stream.Domain.Interfaces;
using Stream.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Domain.Domain
{
    public class YtAudioStreamer : IWebAudioStreamer
    {
        public AudioDescription GetAudioDescription(string url)
        {
            throw new NotImplementedException();
        }

        public object GetAudioStream(string url)
        {
            throw new NotImplementedException();
        }
    }
}

using Stream.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Domain.Interfaces
{
    interface IWebAudioStreamer
    {
        object GetAudioStream(string url);
        AudioDescription GetAudioDescription(string url);
    }
}

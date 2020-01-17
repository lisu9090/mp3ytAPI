using Microsoft.AspNetCore.NodeServices;
using Stream.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Infrastructure.Services
{
    public class YtAudioStreamService : IYtAudioStreamService
    {
        protected INodeServices NodeServices { get; set; }

        public YtAudioStreamService(INodeServices nodeServices)
        {
            NodeServices = nodeServices;
        }

        public System.IO.Stream GetAudioStream(string videoId)
        {
            throw new NotImplementedException();
        }
    }
}

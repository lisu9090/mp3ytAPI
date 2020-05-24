using Microsoft.AspNetCore.NodeServices;
using Stream.Domain.Abstract.Repositories;
using Stream.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Infrastructure.Services
{
    public class YtAudioStreamRepository : IAudioStreamRepository
    {
        protected INodeServices _nodeServices;

        public YtAudioStreamRepository()
        {
            //var options = new NodeServicesOptions();
            //options
            //_nodeServices = new NodeServicesFactory().CreateNodeServices();
        }

        public YtAudioStreamRepository(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }

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

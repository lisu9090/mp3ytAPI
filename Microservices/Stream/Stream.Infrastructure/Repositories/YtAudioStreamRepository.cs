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

        //public YtAudioStreamRepository()
        //{
        //    //var options = new NodeServicesOptions();
        //    //options
        //    //_nodeServices = new NodeServicesFactory().CreateNodeServices();
        //}

        public YtAudioStreamRepository(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }

        public AudioDescription GetAudioDescription(string url)
        {
            return new AudioDescription { id = "" , length = 0, title = "" };
        }

        public System.IO.Stream GetAudioStream(string url)
        {
            return _nodeServices.InvokeAsync<System.IO.Stream>("../NodeScripts/VideoToAudioStream", url).Result;
        }
    }
}

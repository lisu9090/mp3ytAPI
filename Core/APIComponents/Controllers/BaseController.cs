using APIComponents.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIComponents.Controllers
{
    [LoggingActionFilter]
    public class BaseController: ControllerBase
    {
        public ILogger Logger { get; }

        public BaseController(ILogger logger)
        {
            Logger = logger;
        }
    }
}

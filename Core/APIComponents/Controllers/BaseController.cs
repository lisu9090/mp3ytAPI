using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIComponents
{
    [LoggingActionFilter]
    class BaseController: ControllerBase
    {
        public ILogger _logger { get; private set; }

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}

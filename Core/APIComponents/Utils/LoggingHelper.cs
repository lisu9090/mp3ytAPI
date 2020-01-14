using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIComponents.Utils
{
    public class LoggingHelper : ILogger
    {
        private bool _enabled;

        public LoggingHelper(bool enabled = true)
        {
            _enabled = enabled;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            if (!_enabled)
                return null;

            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _enabled;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!_enabled)
                return;

            throw new NotImplementedException();
        }

        public void SwitchHelperEnable(bool value)
        {
            _enabled = value;
        }
    }
}

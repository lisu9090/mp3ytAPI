using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APIComponents.Utils
{
    public class ActionFilterLogger : ILogger
    {
        protected const string logsOrigin = @"..\logs\";
        protected readonly string filePath = "log-" + DateTime.Now.ToString("yy-MM-dd-HH-mm-ss") + ".txt";
        protected LogLevel LogLvl { get; set; }
        protected string _scope;

        public ActionFilterLogger(LogLevel logLevel = LogLevel.Warning)
        {
            LogLvl = logLevel;

            CreateLogFile();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            AddScope(state.ToString());
            return new ScopeManager(state, RemoveScope);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel >= LogLvl )
            {
                return true;
            }

            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            StringBuilder data = new StringBuilder(DateTime.Now.ToString("<yyyy-MM-dd-HH-mm-ss> "));
            data.Append(formatter(state, exception));

            using (StreamWriter sw = File.AppendText(logsOrigin + filePath))
            {
                sw.WriteLine(data.ToString());   
            }
        }

        public void SetLogLevel(LogLevel logLevel)
        {
            LogLvl = logLevel;
        }

        protected void CreateLogFile()
        {
            try
            {
                if (!Directory.Exists(logsOrigin))
                {
                    Directory.CreateDirectory(logsOrigin);
                }
                if (!File.Exists(logsOrigin + filePath))
                {
                    File.Create(logsOrigin + filePath);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not create file or directory: " + e.ToString());
            }

        }

        protected void AddScope(string scope)
        {
            _scope += "/" + scope;
        }

        protected void RemoveScope(string scope)
        {
            var scopesArr = _scope.Split(new char[] { '/' });

            StringBuilder sBuilder = new StringBuilder();

            foreach(var item in scopesArr)
            {
                if (!item.Equals(scope))
                    sBuilder.Append("/" + item);
            }

            _scope = sBuilder.ToString();
        }

        protected class ScopeManager : IDisposable
        {
            private string _state;
            private Action<string> _removeFromScope;
            public ScopeManager(object state, Action<string> removeFromScope)
            {
                _state = state.ToString(); ;
                _removeFromScope = removeFromScope;
            }
            public void Dispose()
            {
                _removeFromScope(_state);
            }
        }
    }
}

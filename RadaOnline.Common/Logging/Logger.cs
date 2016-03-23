namespace RadaOnline.Common.Logging
{
    using System;

    using RadaOnline.Common.Logging.Interfaces;

    public class Logger : ILogger
    {
        public void Error(Exception ex, string message = null)
        {
        }

        public void Warning(string message)
        {
        }

        public void Info(string message)
        {
        }
    }
}

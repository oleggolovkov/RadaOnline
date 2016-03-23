namespace RadaOnline.Common.Logging.Interfaces
{
    using System;

    public interface ILogger
    {
        void Error(Exception ex, string message = null);

        void Warning(string message);

        void Info(string message);
    }
}

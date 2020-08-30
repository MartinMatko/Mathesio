using System;

namespace InternetDiscussion.Tools
{
    public sealed class Logger
    {
        private static Logger _logger;
        private static readonly object _syncLock = new object();

        private Logger()
        {
        }

        public static Logger GetLogger()
        {
            if (_logger == null)
            {
                lock (_syncLock)
                {
                    if (_logger == null)
                    {
                        _logger = new Logger();
                    }
                }
            }

            return _logger;
        }

        public void LogNonExistingAuthor(int authorId)
        {
            var message = String.Format("UserId {0} not found in database", authorId.ToString());
            Console.WriteLine(DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’") + ": " + message);
        }
    }
}

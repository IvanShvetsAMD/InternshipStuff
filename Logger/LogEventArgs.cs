namespace LoggerService
{
    public class LogEventArgs
    {
        public readonly Logger Log;
        public readonly string LogText;

        public LogEventArgs(Logger a = null, string b = null)
        {
            Log = a;
            LogText = b;
        }

        public LogEventArgs(string a)
        {
            Log = null;
            LogText = a;
        }
    }
}
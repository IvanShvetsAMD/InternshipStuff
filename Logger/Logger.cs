using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public delegate void LogChangedDelegate(LogEventArgs e);
    public class Logger : IDisposable
    {
        static Lazy<Logger> lazyInstance = new Lazy<Logger>(() => new Logger(), true);
        private string Log;
        private string directory = "D:\\";
        private string filename = "Log file";
        public event LogChangedDelegate LogChangedEvent;



        public string Directory
        {
            private get { return directory; }
            set
            {
                AddToLog("Log file directory changed to " + value);
                directory = value;
            }
        }

        public string FileName
        {
            private get { return filename; }
            set
            {
                AddToLog("Log file name changed to '" + value + ".txt'");
                filename = value;
            }
        }

        private Logger() { }

        public static Logger GetLogger() => lazyInstance.Value;

        public void AddToLog(string a)
        {
            StringBuilder add = new StringBuilder();
            add.AppendFormat("{0}[{1}] {2}", Environment.NewLine, DateTime.Now, a);
            Log += add;

            LogChangedDelegate handler = LogChangedEvent;
            if (handler != null)
                handler(new LogEventArgs(add.ToString()));
        }

        public void AddToLogWithOffset(string a)
        {
            StringBuilder add = new StringBuilder();
            add.AppendFormat("{0}[{1}] {2}", Environment.NewLine, DateTimeOffset.Now, a);
            Log += add;

            LogChangedDelegate handler = LogChangedEvent;
            if (handler != null)
                handler(new LogEventArgs(add.ToString()));
        }

        public void AddToLog(LogEventArgs args)
        {
            if (args.Log != null)
                AddToLog(args.Log.Log);
            AddToLog(args.LogText);
        }

        public void ExportToFile()
        {
            StringBuilder add = new StringBuilder();
            add.AppendFormat(@"Log exported to file ({0}\{1}.txt):", Directory, FileName);
            AddToLog(add.ToString());
            using (StreamWriter file = new StreamWriter(Directory + "\\" + FileName + ".txt", true, Encoding.Unicode))
                file.WriteLineAsync(ToString());
        }

        public override string ToString() => String.Format("Log ({0}): {1}", DateTime.Now, Log);

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        ~Logger()
        {
            Log = null;
            lazyInstance = null;
        }

        public void Dispose()
        {
            AddToLog("Terminating");
            //StringBuilder add = new StringBuilder();
            //add.AppendFormat(@"Log exported to file ({0}\{1}.txt):", Directory, FileName);
            //using (StreamWriter file = new StreamWriter(Directory + "\\" + FileName + ".txt", true, Encoding.Unicode))
            //    file.WriteLineAsync(add.ToString());
            ExportToFile();
        }

        public bool FindInLog(string str) => Log.Contains(str);

        public TimeSpan CalculatePostTimeDifference()
        {
            TimeSpan dif = new TimeSpan();

            var i2 = Log.LastIndexOf("]");
            var i1 = Log.Substring(0, i2).LastIndexOf("[");

            dif = DateTimeOffset.Now - DateTimeOffset.Parse(Log.Substring(i1 + 1, i2 - i1 - 1));

            return dif;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public delegate void LogChangedDelegate(LogEventArgs e);
    public class Logger
    {
        private string Log;
        private string directory = "D:\\";
        private string filename = "Voting Server Log";

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

        public LogChangedDelegate LogChangedEvent;

        public Logger() { }

        public void AddToLog(string a)
        {
            Log += Environment.NewLine + "[" + DateTime.Now + "] " + a;

            LogChangedDelegate handler = LogChangedEvent;
            handler?.Invoke(new LogEventArgs(this));
        }

        public void ExportToFile()
        {
            AddToLog("Log exported to file (" + Directory + "\\" + FileName + ".txt)");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Directory + "\\" + FileName + ".txt", true))
                file.WriteLine(ToString());
        }

        public override string ToString()
        {
            return String.Format("Log ({0}): {1}", DateTime.Now, Log);
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }
    }
}
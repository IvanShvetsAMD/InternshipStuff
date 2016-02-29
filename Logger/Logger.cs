﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public delegate void LogChangedDelegate(LogEventArgs e);
    public class Logger
    {
        static Lazy<Logger> LazyInstance = new Lazy<Logger>(() => new Logger(), true);
        private string Log;
        private string directory = "D:\\";
        private string filename = "Voting Server Log";
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

        public static Logger GetLogger() => LazyInstance.Value;

        public void AddToLog(string a)
        {
            string addition = Environment.NewLine + "[" + DateTime.Now + "] " + a;
            Log += addition;

            LogChangedDelegate handler = LogChangedEvent;
            if (handler != null)
                handler(new LogEventArgs(addition));
        }

        public void AddToLog(LogEventArgs args)
        {
            if (args.Log != null)
                AddToLog(args.Log.Log);
            AddToLog(args.LogText);
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
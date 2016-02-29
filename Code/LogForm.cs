using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoggerService;

namespace PresentationCode
{
    public partial class LogForm : Form
    {
        private static Lazy<LogForm> lazyInstance = new Lazy<LogForm>(() => new LogForm(Logger.GetLogger()), true); 
        
        public static LogForm GetLogForm() => lazyInstance.Value;

        private LogForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = Logger.GetLogger().ToString();
        }
        private LogForm(Logger log)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            log.LogChangedEvent += LogChangedEventHandler;
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = log.ToString();
        }

        private void LogChangedEventHandler(LogEventArgs e)
        {
            Invoke((Action) delegate { richTextBox1.Text = e.Log.ToString(); });
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }
    }
}
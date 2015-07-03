using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ex_WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private Timer MyTimer;
        public Service1()
        {
            InitializeComponent();
            this.AutoLog = false;
            if (!System.Diagnostics.EventLog.SourceExists("Ex-WinService"))
            {
                System.Diagnostics.EventLog.CreateEventSource("Ex-WinService", "Ex-Log");
            }
            eventLog1.Source = "Ex-WinService";
        }

        protected override void OnStart(string[] args)
        {
            MyTimer = new Timer();
            MyTimer.Elapsed +=new ElapsedEventHandler(MyTimer_Elapsed);
            MyTimer.Interval = 10*1000;
            MyTimer.Start();
        }

        private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            eventLog1.WriteEntry("Timer Ticked. and Now:" + DateTime.Now);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Stop Timer.");
            MyTimer.Stop();
            MyTimer = null;
        }
    }
}

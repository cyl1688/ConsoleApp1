using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    class DoThing
    {
        private readonly Timer _timer; //using System.Timers;
        private static ILogger s_logger; //using NLog;

        static DoThing()
        {
            if (s_logger == null)
            {
                s_logger = LogManager.GetCurrentClassLogger();
            }
        }
        public DoThing()
        {
            this._timer = new Timer(1000) { AutoReset = true };
            //this._timer.Elapsed += (sender, eventArgs) => Console.WriteLine($"Now Time:{DateTime.Now}");
            this._timer.Elapsed += (sender, eventArgs) => s_logger.Debug($"Now Time:{DateTime.Now}");
        }

        public void TTT()
        {

        }

        public void Start()
        {
            this._timer.Start();
            try
            {
                s_logger.Trace($"Timer Start");
                s_logger.Debug($"Timer Start");
            }
            catch(Exception ex)
            {
                string strMsg = ex.Message;
            }


        }

        public void Stop()
        {
            this._timer.Stop();
            s_logger.Trace($"Timer Stop");
            LogManager.Flush();
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace SimpleHeartBeatService
{
    public class HeartBeat
    {
        private readonly Timer _timer;
        public HeartBeat()
        {
            _timer = new Timer( 1000) { AutoReset=true};
            _timer.Elapsed += _Timer_Elapsed;
        }

        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Users\chetan_bora\Desktop\SimpleHeartBeatService\HeartBeat.txt",lines);

        }

        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }

        
    }
}

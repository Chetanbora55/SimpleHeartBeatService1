using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Runtime.Windows;

namespace SimpleHeartBeatService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<HeartBeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new HeartBeat());
                    s.WhenStarted(heartbeat=> heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("HeartBeatService");
                x.SetDisplayName("Heart Beat Service");
                x.SetDescription("Practice Service Description");
            });

            int exitcodevalue = (int)Convert.ChangeType(exitCode,exitCode.GetTypeCode());
            Environment.Exit(exitcodevalue);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DirCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Check>(s =>
                {
                    s.ConstructUsing(check => new Check());
                    s.WhenStarted(check => check.Start());
                    s.WhenStopped(check => check.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("DirCheck");
                x.SetDisplayName("Directory Check");
                x.SetDescription("Check directory and move files if amount >100");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}

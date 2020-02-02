using NLog;
using System;
using System.Activities.Presentation;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ConsoleApp1
{
    class Program
    {

        #region Test
        //private static ILogger logger;
        //static void Main(string[] args)
        //{
        //    LogManager.ThrowExceptions = true;
        //    logger = LogManager.GetCurrentClassLogger();
        //    int logcount = 1000000;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        LogToFile(i, logcount);
        //    }
        //}

        //private static void LogToFile(int index, int logcount)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    for (int i = 0; i < logcount; i++)
        //    {
        //        logger.Debug($"{index}_{i}_{DateTime.Now}");
        //    }
        //    sw.Stop();
        //    logger.Info($"{index}_log 筆數：{logcount};總耗時毫秒：{sw.ElapsedMilliseconds}");
        //    LogManager.Flush();
        //}
        #endregion

        static void Main(string[] args)
        {

            HostFactory.Run(x =>
            {
                x.Service<DoThing>(s =>
                {
                    s.ConstructUsing(name => new DoThing());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.UseNLog(); //NLog
                x.RunAsLocalSystem();
                var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                x.SetDescription("Sample Topshelf Host");
                x.SetDisplayName(assemblyName);
                x.SetServiceName(assemblyName);
            });
        }



        //internal class WindowsServiceConfig
        //{
        //    public static void Configure()
        //    {
        //        HostFactory.Run(x =>
        //        {
        //            x.Service<DoThing>(s =>
        //            {
        //                s.ConstructUsing(name => new DoThing());
        //                s.WhenStarted(tc => tc.Start());
        //                s.WhenStopped(tc => tc.Stop());
        //            });
        //            x.RunAsLocalSystem();
        //            var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
        //            x.SetDescription("Sample Topshelf Host");
        //            x.SetDisplayName(assemblyName);
        //            x.SetServiceName(assemblyName);
        //        });
        //    }

        //    public static void ConfigureWithMultiService()
        //    {
        //        //using System.Activities.Presentation;
        //        HostFactory.Run(x =>
        //        {
        //            x.Service<ServiceManager>(s =>
        //            {
        //                ServiceManager.Container.Add<Service1>();
        //                ServiceManager.Container.Add<Service2>();

        //                s.ConstructUsing(name => new ServiceManager());
        //                s.WhenStarted(tc => tc.Start());
        //                s.WhenStopped(tc => tc.Stop());
        //            });
        //            x.UseNLog();
        //            x.RunAsLocalSystem();
        //            var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
        //            x.SetDescription("Sample Topshelf Host");
        //            x.SetDisplayName(assemblyName);
        //            x.SetServiceName(assemblyName);
        //        });
        //    }

        //    public static void ConfigureWithNLog()
        //    {
        //        //using Topshelf;
        //        HostFactory.Run(x =>
        //        {
        //            x.Service<DoThing>(s =>
        //            {
        //                s.ConstructUsing(name => new DoThing());
        //                s.WhenStarted(tc => tc.Start());
        //                s.WhenStopped(tc => tc.Stop());
        //            });
        //            x.UseNLog();
        //            x.RunAsLocalSystem();
        //            var assemblyName = Assembly.GetEntryAssembly().GetName().Name; //using System.Reflection;
        //            x.SetDescription("Sample Topshelf Host");
        //            x.SetDisplayName(assemblyName);
        //            x.SetServiceName(assemblyName);
        //        });
        //    }
        //}
    }
}

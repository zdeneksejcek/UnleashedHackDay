using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SalesOrderOrleans.Contracts.Command;
using SalesOrderOrleans.Handlers;

namespace SalesOrderOrleans
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // The Orleans silo environment is initialized in its own app domain in order to more
            // closely emulate the distributed situation, when the client and the server cannot
            // pass data via shared memory.
            AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null, new AppDomainSetup
            {
                AppDomainInitializer = InitSilo,
                AppDomainInitializerArguments = args,
            });

            Orleans.OrleansClient.Initialize("DevTestClientConfiguration.xml");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var sos = 
                new UseCases.CreateSalesOrdersUseCase().Execute(1000);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //var reList = new List<Task>(1000);
            //foreach (var ha in Enumerable.Range(1, 1000))
            //{
            //    reList.Add(new CreateSalesOrderHandler().Execute(new CreateSalesOrderCommand(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid())));
            //    Console.WriteLine("New: " + ha);
            //}

            // Task.WaitAll(reList.ToArray());
            
            // TODO: once the previous call returns, the silo is up and running.
            //       This is the place your custom logic, for example calling client logic
            //       or initializing an HTTP front end for accepting incoming requests.

            Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
            Console.ReadLine();

            hostDomain.DoCallBack(ShutdownSilo);
        }

        static void InitSilo(string[] args)
        {
            hostWrapper = new OrleansHostWrapper(args);

            if (!hostWrapper.Run())
            {
                Console.Error.WriteLine("Failed to initialize Orleans silo");
            }
        }

        static void ShutdownSilo()
        {
            if (hostWrapper != null)
            {
                hostWrapper.Dispose();
                GC.SuppressFinalize(hostWrapper);
            }
        }

        private static OrleansHostWrapper hostWrapper;
    }
}

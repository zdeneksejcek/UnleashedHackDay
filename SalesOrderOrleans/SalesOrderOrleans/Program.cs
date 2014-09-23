using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.GrainsCollection.Observers;

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

            var list = new List<Guid>();
            var useCase = new UseCases.CreateSalesOrdersUseCase();

            var referenceList = SalesOrdersObserverFactory.CreateObjectReference(new SalesOrderListObserver()).Result;
            var referenceDashboard = SalesOrdersObserverFactory.CreateObjectReference(new OrdersDashboardObserver()).Result;


            useCase.Subscribe(referenceList);
            useCase.Subscribe(referenceDashboard);

            foreach (var i in Enumerable.Range(0, 5))
            {
                list.AddRange(useCase.Execute(100));
            }

            new UseCases.AddSalesOrderLinesUseCase().Execute(list.ToList());

            new UseCases.CompleteSalesOrdersUseCase().Execute(list.ToList());

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

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

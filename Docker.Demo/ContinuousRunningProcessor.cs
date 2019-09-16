using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Docker.Demo
{
    internal class ContinuousRunningProcessor
    {
        private static readonly AutoResetEvent _closingEvent = new AutoResetEvent(false);
        private readonly IConsolePrinter consolePrinter;
        private readonly ILogger<ContinuousRunningProcessor> logger;

        public ContinuousRunningProcessor(IConsolePrinter consolePrinter, ILogger<ContinuousRunningProcessor> logger)
        {
            this.consolePrinter = consolePrinter;
            this.logger = logger;
        }

        public void Process()
        {
            var count = 0;

            Task.Factory.StartNew(() =>
            {
                logger.LogInformation("Process started!");
                while (true)
                {
                    consolePrinter.Print(++count);
                    Thread.Sleep(1000);
                }
            });

            Console.WriteLine("Press Ctrl + C to cancel!");
            Console.CancelKeyPress += ((s, a) =>
            {
                Console.WriteLine("Bye!");
                _closingEvent.Set();
            });

            _closingEvent.WaitOne();
        }
    }
}

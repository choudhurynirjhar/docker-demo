using System;
using System.Threading;
using System.Threading.Tasks;

namespace Docker.Demo
{
    class Program
    {
        private static readonly AutoResetEvent _closingEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Docker World!");
            var count = 0;

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine($"Current Count {++count}");
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

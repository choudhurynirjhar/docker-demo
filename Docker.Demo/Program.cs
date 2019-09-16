using System;
using Microsoft.Extensions.DependencyInjection;

namespace Docker.Demo
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Docker World!");

            var serviceProvider = ContainerConfiguration.Configure();
            serviceProvider.GetService<ContinuousRunningProcessor>().Process();
        }
    }
}

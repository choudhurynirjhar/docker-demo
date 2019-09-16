using System;

namespace Docker.Demo
{
    internal class ConsolePrinter : IConsolePrinter
    {
        private readonly IPrintSettingsProvider printSettingsProvider;

        public ConsolePrinter(IPrintSettingsProvider printSettingsProvider)
        {
            this.printSettingsProvider = printSettingsProvider;
        }

        public void Print(int count)
        {
            if (printSettingsProvider.CanPrint())
            {
                Console.WriteLine($"Current Count {count}");
            }
        }
    }
}

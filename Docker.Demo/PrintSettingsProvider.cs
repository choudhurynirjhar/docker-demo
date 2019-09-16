using System;
using System.Collections.Generic;
using System.Text;

namespace Docker.Demo
{
    internal class PrintSettingsProvider : IPrintSettingsProvider
    {
        public bool CanPrint()
        {
            return true;
        }
    }
}

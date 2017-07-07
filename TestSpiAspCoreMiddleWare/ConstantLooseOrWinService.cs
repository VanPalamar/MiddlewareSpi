using System;
using TestSpiAspCoreMiddleWare.Services;

namespace TestSpiAspCoreMiddleWare
{
    internal class ConstantLooseOrWinService : ILooseOrWinService
    {
        public bool IsWIn()
        {
            return Environment.TickCount % 2 == 0;
        }
    }
}
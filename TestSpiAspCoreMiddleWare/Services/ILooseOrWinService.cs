﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestSpiAspCoreMiddleWare.Services
{
    interface ILooseOrWinService
    {
        bool IsWIn();
    }
}
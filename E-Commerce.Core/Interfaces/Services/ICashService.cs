﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Interfaces.Services
{
    public interface ICashService
    {
        Task SetCashResponseAsync(string Key, object response, TimeSpan time);

        Task<string?> GetCashResponseAsync(string Key);
    }
}

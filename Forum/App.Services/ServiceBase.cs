﻿using NLog;

namespace App.Services
{
    public abstract class ServiceBase
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();
    }
}

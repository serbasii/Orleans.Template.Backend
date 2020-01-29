using Orleans.Concurrency;
using SimpleLoggingInterfaces.Enums;
using SimpleLoggingInterfaces.Interfaces;
using SimpleLoggingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLoggingService.Grains
{
    [Immutable]
    public class PayloadEntity 
    {
        public EnumCollection.LogType LogType { get; set; }
        public ILogPayload Payload { get; set; }
    }
}

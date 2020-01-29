using SimpleLoggingInterfaces.Enums;
using SimpleLoggingInterfaces.Interfaces;
using SimpleLoggingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLoggingService.Grains
{
    public class ApplicationEntity 
    { 
        public string ApplicationMessage { get; set; }
        public string CurrentMethod { get; set; }
        public bool WrittenToPlatform { get; set; }
        public bool OnlyInnerException { get; set; }
        public string Note { get; set; }
        public EnumCollection.LogLevel LogLevel { get; set; }
        public Exception Error { get; set; }
        public string Application { get; set; }
        public DateTime DateTime { get; set; }
    }
}

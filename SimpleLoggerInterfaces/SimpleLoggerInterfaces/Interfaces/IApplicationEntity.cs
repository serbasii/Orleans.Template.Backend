using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLoggerInterfaces.Interfaces
{
    public interface IApplicationEntity : IEntityBase
    {
        string ApplicationMessage { get; set; }
        string CurrentMethod { get; set; }
    }
}
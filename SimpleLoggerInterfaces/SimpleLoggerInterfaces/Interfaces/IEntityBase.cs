using System;
using static SimpleLoggerInterfaces.Enums.EnumCollection;

namespace SimpleLoggerInterfaces.Interfaces
{
    public interface IEntityBase
    {
        bool WrittenToPlatform { get; set; }
        bool OnlyInnerException { get; set; }
        string Note { get; set; }
        LogLevel LogLevel { get; set; }
        Exception Error { get; set; }
    }
}
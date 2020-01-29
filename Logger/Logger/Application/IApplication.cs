using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Application
{
    public interface IApplication
    {
        void Info(string message);

        void Debug(string message);

        void Error(Exception exception);

        void Error(Exception exception, string note);
    }
}
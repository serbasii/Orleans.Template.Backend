using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Application
{
    internal class Application : IApplication
    {
        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string note)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }
    }
}
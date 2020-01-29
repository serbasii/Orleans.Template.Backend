using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Queue
{
    public interface IQueue
    {
        void Pop(string message);

        void Push(string message);

        void Error(Exception exception);

        void Error(string message, Exception exception);
    }
}
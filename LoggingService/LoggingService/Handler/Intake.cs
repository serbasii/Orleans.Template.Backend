using SimpleLoggingInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Handler
{
    public class Intake
    {
        public void MessageLogging(byte[] message)
        {
            var decodedMessage = Encoding.UTF8.GetString(message);
        }
    }
}
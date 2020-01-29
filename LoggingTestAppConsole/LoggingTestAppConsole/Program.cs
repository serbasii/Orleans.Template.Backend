using RabbitMQ.Client;
using SimpleLoggingClient.LoggingInterfaces;
using System;
using System.Reflection;
using System.Text;
using static SimpleLoggingInterfaces.Enums.EnumCollection;

namespace LoggingTestAppConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ILog log = new SimpleLoggingClient.Log("LoggingTestAppConsole", "localHost", "guest", "guest", "/",
                5672, "AMQP default", "TestQueue", "TestQueue", LogLevel.Info, true);

            log.Application.Message(LogLevel.Error, "This is a test", MethodBase.GetCurrentMethod().Name, true);

            Console.WriteLine("Hello World!");
            ILog logger = new SimpleLoggingClient.Log("LoggingTestAppConsole", "localHost", "guest", "guest", "LoggingTestAppConsole",
                5672, "Leo", "Family", "Cora", LogLevel.Debug, true);

            logger.Application.Message(LogLevel.Info, "This is a test", MethodBase.GetCurrentMethod().Name, true);

            Setup();
            SendMessage();
        }

        private static void Setup()
        {
            string UserName = "guest";
            string Password = "guest";
            string HostName = "localhost";

            //Main entry point to the RabbitMQ .NET AMQP client
            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
            {
                UserName = UserName,
                Password = Password,
                HostName = HostName
                //Port = 6000
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            Console.WriteLine("Creating Exchange");

            // Create Exchange
            model.ExchangeDeclare("Tom", ExchangeType.Direct);
            model.QueueDeclare("Jen", true, false, false, null);
            Console.WriteLine("Creating Queue");
            model.QueueBind("demoqueue", "demoExchange", "directexchange_key");
            Console.WriteLine("Creating Binding");
        }

        private static void SendMessage()
        {
            string UserName = "guest";
            string Password = "guest";
            string HostName = "localhost";

            //Main entry point to the RabbitMQ .NET AMQP client
            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
            {
                UserName = UserName,
                Password = Password,
                HostName = HostName
                //Port = 6000
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            var properties = model.CreateBasicProperties();
            properties.Persistent = false;
            byte[] messagebuffer = Encoding.Default.GetBytes("Direct Message" + DateTime.Now);

            model.BasicPublish("demoExchange", "directexchange_key", properties, messagebuffer);
            Console.WriteLine("Message Sent");

            var message = model.BasicGet("demoqueue", true);
            Console.WriteLine("message: " + Encoding.Default.GetString(message.Body));
        }
    }
}
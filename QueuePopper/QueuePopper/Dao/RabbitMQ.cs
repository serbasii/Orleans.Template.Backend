using QueuePopper.Interfaces;
using RabbitMQ.Client;
using System;
using System.Threading.Tasks;

namespace QueuePopper.Dao
{
    public class RabbitMQ : IDao
    {
        private readonly string QUEUE_HOSTNAME = "Queue_Hostname";
        private const string QUEUE_USERNAME = "Queue_Username";
        private const string QUEUE_PASSWORD = "Queue_Password";
        private const string QUEUE_VIRTUALHOST = "Queue_Virtual_Host";
        private const string QUEUE_PORT = "Queue_Port";
        private const string QUEUE_QUEUENAME = "Queue_Name";
        private const string QUEUE_AUTO_ACK = "Queue_AutoAck";

        private readonly string _queue;
        private readonly bool _autoAck;

        private ConnectionFactory _factory;

        public RabbitMQ()
        {
            _factory = new ConnectionFactory()
            {
                HostName = Environment.GetEnvironmentVariable(QUEUE_HOSTNAME),
                UserName = Environment.GetEnvironmentVariable(QUEUE_USERNAME),
                Password = Environment.GetEnvironmentVariable(QUEUE_PASSWORD),
                VirtualHost = Environment.GetEnvironmentVariable(QUEUE_VIRTUALHOST),
                Port = Convert.ToInt32(Environment.GetEnvironmentVariable(QUEUE_PORT))
            };

            _queue = Environment.GetEnvironmentVariable(QUEUE_QUEUENAME);
            _autoAck = Convert.ToBoolean(Environment.GetEnvironmentVariable(QUEUE_AUTO_ACK));
        }

        public async Task<BasicGetResult> GetMessage()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var connection = _factory.CreateConnection())
                    {
                        using (var channel = connection.CreateModel())
                        {
                            return channel.BasicGet(_queue, _autoAck);
                        }
                    }
                });

                return null;
            }
            catch (Exception ex)
            {
                //todo: set up logger

                return null;
            }
        }
    }
}
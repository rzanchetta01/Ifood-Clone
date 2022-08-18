using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Transactions;

namespace MessageQueue
{
    public class RabbitMQ : IDisposable
    {
        private readonly ConnectionFactory _factory;
        private static IConnection? _conn;
        private static IModel? _channel;
        private string _route;
        private bool disposedValue;

        public RabbitMQ(string route)
        {
            _route = route;
            Console.WriteLine("about to connect to rabbit");

            _factory = new() { Uri = new Uri("amqp://guest:guest@localhost"), UserName = "guest", Password = "guest" };

            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: route,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            Console.WriteLine("connected to rabbit");
        }
        public void ChangeRoute(string newRoute)
        {
            _route = newRoute;
        }

        public bool Publish(byte[] data)
        {

            _channel.BasicPublish(exchange: string.Empty,
                                    routingKey: _route,
                                    basicProperties: null,
                                    body: data);

            Console.WriteLine("msg published");

            return true;

        }

        public List<byte[]> Consume()
        {
            var listeningQueuesCount = 1;
            var cancellationTokenSource = new CancellationTokenSource();
            List<byte[]> result = new();

            for (var queueIndex = 0; queueIndex < listeningQueuesCount; queueIndex++)
            {
                var thread = new Thread(() => DisplayQueueMessage(_route, cancellationTokenSource, out result));
                thread.Start();
            }

            Console.WriteLine($"Consumer created successfully and listening to {listeningQueuesCount} queue(s).");                        
            WaitHandle.WaitAny(new[] { cancellationTokenSource.Token.WaitHandle });
            return result;

        }
        private static void DisplayQueueMessage(string queueName, CancellationTokenSource cancellationToken, out List<byte[]> result)
        {
            result = new();

            while (!cancellationToken.Token.IsCancellationRequested)
            {   
                BasicGetResult? get = _channel?.BasicGet(queueName, false);
                if (get != null)
                {
                    result.Add(get.Body.ToArray());
                    _channel?.BasicAck(get.DeliveryTag, false);
                }
                else
                {   
                    cancellationToken.Cancel();
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if(_conn is not null)
                        _conn.Dispose();

                    if(_channel is not null)
                        _channel.Dispose();
                }

                
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RabbitMQ()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
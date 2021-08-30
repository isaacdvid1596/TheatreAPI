using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Theatre.PaymentSystem
{
    public class PaymentService : BackgroundService
    {
        private readonly ILogger<PaymentService> _logger;

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;

        public PaymentService(ILogger<PaymentService> logger)
        {
            _logger = logger;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("payment-queue", false, false, false, null);
            _consumer = new EventingBasicConsumer(_channel);
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _consumer.Received += async (model, content) =>
            {
                var body = content.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                var paymentInformation = JsonConvert.DeserializeObject<PaymentInformation>(json);
                var paymentResult = await ProcessPayment(paymentInformation, cancellationToken);
                Console.WriteLine($"El pago para {paymentInformation.BasketId} fue existoso : {paymentResult}");
            };

            _channel.BasicConsume("payment-queue", true, _consumer);
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task<bool> ProcessPayment(PaymentInformation paymentInformation, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(paymentInformation.Name))
            {
                return false;
            }

            await Task.Delay(2000, cancellationToken);

            if (string.IsNullOrEmpty(paymentInformation.Code))
            {
                return false;
            }

            await Task.Delay(2000, cancellationToken);

            if (paymentInformation.ValidThrough <= DateTime.Now)
            {
                return false;
            }

            return true;

        }
    }
}

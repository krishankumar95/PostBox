using Microsoft.Extensions.Options;
using PostBox.Common.Core;
using PostBox.Common.Core.Notifications;
using PostBox.Common.DataAccess.DAL;
using PostBox.Outbound.Relayer.Interface.Models;
using RabbitMQ.Client;

namespace PostBox.Outbound.Relayer.Interface.Relayers
{
	public class RabbitMqOutboundRelayer:IPostboxOutboundRelayer
	{
        private readonly IPostboxMessageRepository postboxMessageRepository;
        private readonly PostboxOutboundRelayerConfig relayerConfig;

        public RabbitMqOutboundRelayer(IPostboxMessageRepository postboxMessageRepository,IOptions<PostboxOutboundRelayerConfig> config)
		{
            this.postboxMessageRepository = postboxMessageRepository;
            this.relayerConfig = config.Value;
        }

        public Task ExecuteAsync()
        {
            var enumerable = postboxMessageRepository.GetAllMessages();
            var toPost = enumerable.Where(x => x.Status == Common.Core.DeliveryStatus.POSTED);

            foreach (var msg in toPost)
            {
                RelayMessage(msg);
            }

            return Task.CompletedTask;
        }

        public Task Handle(MessageIngestedNotification notification, CancellationToken cancellationToken)
        {
            RelayMessage(postboxMessageRepository.GetMessageWithId(notification.MessageId));
            return Task.CompletedTask;
        }

        public void RelayMessage(PostboxMessage msg)
        {
            var deliveryParams = (RabbitMqDeliveryParameteres)msg.DeliveryParameters;
            var factory = new ConnectionFactory { HostName = relayerConfig.DatabaseUri };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var props = channel.CreateBasicProperties();
            channel.QueueDeclare(queue: deliveryParams.QueueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.BasicPublish(exchange: deliveryParams.ExchangeName,
                                 routingKey: deliveryParams.QueueName,
                                 basicProperties: props,
                                 body: msg.MessageBody);
        }



    }
}


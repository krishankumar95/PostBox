using Microsoft.Extensions.Options;
using PostBox.Common.Core;
using PostBox.Common.Core.Notifications;
using PostBox.Common.DataAccess.DAL;
using PostBox.Outbound.Relayer.Interface.Models;
using PostBox.Outbound.Relayer.Interface.Models.RabbitMq;
using RabbitMQ.Client;

namespace PostBox.Outbound.Relayer.Interface.Relayers.RabbitMq
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
            var deliveryParams = new RabbitMqDeliveryParameteres(msg.DeliveryParameters); //Needs a helper function to translate generic MQ config to specific config
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
                                 routingKey: deliveryParams.RoutingKey,
                                 basicProperties: props,
                                 body: msg.MessageBody);
        }



    }
}


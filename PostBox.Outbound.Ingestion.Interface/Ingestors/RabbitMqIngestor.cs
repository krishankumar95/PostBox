using System;
using PostBox.Common.DataAccess.DAL;
using PostBox.Common.Core;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;

namespace PostBox.Outbound.Ingestion.Interface.Ingestors
{
	public class RabbitMqIngestor<T>:IPostboxOutboundIngestor<T>
	{
        private readonly IPostboxMessageRepository _messageRepository;

        public RabbitMqIngestor(IPostboxMessageRepository messageRepository)
		{
            _messageRepository = messageRepository;
        }

        public DeliveryParameters DeliveryParameters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task PublishMessage(T message)
        {
            var postboxMsg = await GeneratePostboxMessage(message, DeliveryParameters);
            await _messageRepository.CreateMessage(postboxMsg);
        }

        public async Task PublishMessage(T message, DeliveryParameters deliveryParameters)
        {
            var postboxMsg = await GeneratePostboxMessage(message, deliveryParameters);
            await _messageRepository.CreateMessage(postboxMsg);
        }

        private Task<PostboxMessage> GeneratePostboxMessage(T msg,DeliveryParameters deliveryParameters)
        {
            //TODO: Serliaser choice as per user XML , JSON
            var serliasedMsg = JsonSerializer.Serialize(msg);
            //TODO: Encoding as specified by user
            var msgBytes = Encoding.UTF8.GetBytes(serliasedMsg);


            var postboxMsg = new PostboxMessage();
            postboxMsg.DeliveryParameters = deliveryParameters;
            postboxMsg.MessageBody = msgBytes;
            var rnd = new Random();
            postboxMsg.Id = (ulong)rnd.NextInt64();
            return Task.FromResult(postboxMsg);
        }


    }
}


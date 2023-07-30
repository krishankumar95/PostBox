using PostBox.Common.DataAccess.DAL;
using PostBox.Common.Core;
using System.Text;
using System.Text.Json;
using MediatR;
using PostBox.Common.Core.Notifications;

namespace PostBox.Outbound.Ingestion.Interface.Ingestors
{
	public class RabbitMqIngestor<T>:IPostboxOutboundIngestor<T>
	{
        private readonly IPostboxMessageRepository _messageRepository;
        private readonly IMediator _mediator; 


        public RabbitMqIngestor(IPostboxMessageRepository messageRepository,IMediator mediator)
		{
            _messageRepository = messageRepository;
            _mediator = mediator;
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
            await _mediator.Publish(new MessageIngestedNotification(postboxMsg.Id));
        }

        private Task<PostboxMessage> GeneratePostboxMessage(T msg,DeliveryParameters deliveryParameters)
        {
            //TODO: Extract the reusable portion across brokers
            //TODO: Serliaser choice as per user XML , JSON
            var serliasedMsg = JsonSerializer.Serialize(msg);
            //TODO: Encoding as specified by user
            var msgBytes = Encoding.UTF8.GetBytes(serliasedMsg);

            var postboxMsg = new PostboxMessage();
            postboxMsg.DeliveryParameters = deliveryParameters;
            postboxMsg.MessageBody = msgBytes;
            if (!string.IsNullOrEmpty(deliveryParameters.ConnectionTag))
            {
                postboxMsg.PostboxHeaders = new Dictionary<PostboxHeaders, object>();
                postboxMsg.PostboxHeaders.Add(PostboxHeaders.CONNECTION_TAG, deliveryParameters.ConnectionTag);
            }
            postboxMsg.Status = DeliveryStatus.POSTED;
            postboxMsg.Id = Guid.NewGuid().ToString();
            return Task.FromResult(postboxMsg);
        }


    }
}


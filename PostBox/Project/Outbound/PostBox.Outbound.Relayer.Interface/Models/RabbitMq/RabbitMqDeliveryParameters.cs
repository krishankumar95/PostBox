using System;
using PostBox.Common.Core;

namespace PostBox.Outbound.Relayer.Interface.Models.RabbitMq
{
    public class RabbitMqDeliveryParameteres
    {
        //Add MQ Specific Configs here
        public string RoutingKey { get; set; }
        public string ExchangeName { get; set; }
        public string QueueName { get; set; }

        public RabbitMqDeliveryParameteres(DeliveryParameters parameters)
        {
            if (parameters.EntityType == MessagingEntityType.Queue)
            {
                QueueName = parameters.EntityName;
                RoutingKey = parameters.EntityName;
                ExchangeName = string.Empty; //RMQ uses default exchange for non attached Qs
            }
            else //Topic and Exchange
            {
                ExchangeName = parameters.EntityName;
            }
        }
    }
}
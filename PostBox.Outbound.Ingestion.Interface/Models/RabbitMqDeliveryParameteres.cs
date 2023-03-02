using System;
using PostBox.Common.Core;

namespace PostBox.Outbound.Ingestion.Interface.Models
{
	public class RabbitMqDeliveryParameteres : DeliveryParameters
	{
		public string QueueName {get ; set;}
		public string ExchangeName { get; set; }
		public string RoutingKey { get; set; }


		public RabbitMqDeliveryParameteres()
		{
		}
	}
}


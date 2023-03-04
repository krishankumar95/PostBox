using System;
//TODO: Fix this file somewhere apt
namespace PostBox.Common.Core
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


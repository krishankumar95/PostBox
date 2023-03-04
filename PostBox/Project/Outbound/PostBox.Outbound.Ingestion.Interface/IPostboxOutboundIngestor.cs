using System;
using PostBox.Common.Core;

namespace PostBox.Outbound.Ingestion.Interface
{
	public interface IPostboxOutboundIngestor<T>
	{
		/// <summary>
		/// Holds the default configuration for the Object T to be delivered
		/// Idea is to have 1:1 ObjType:Ingestor
		/// </summary>
		DeliveryParameters DeliveryParameters { get; set; } //TODO: Can this be made just set only for immutability


		//TODO: Wire a pre-method that routes to apt ingestor
		Task PublishMessage(T message);

		/// <summary>
		/// If T needs to be delivered to anything other than default Publisher Configuration
		/// </summary>
		/// <param name="message"></param>
		/// <param name="deliveryParameters"></param>
		/// <returns></returns>
		Task PublishMessage(T message, DeliveryParameters deliveryParameters);
    }
}


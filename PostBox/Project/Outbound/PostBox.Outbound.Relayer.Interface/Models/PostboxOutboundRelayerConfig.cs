using System;
using PostBox.Common.Core;

namespace PostBox.Outbound.Relayer.Interface.Models
{
	public class PostboxOutboundRelayerConfig
	{
		//Broker Params
		public BrokerType Type { get; set; }
		public string MqConnectionUri { get; set; }
		public string ConnectionTag { get; set; }

		//Datasource Params
		public string DatabaseUri { get; set; }
		public string DatabaseType { get; set; }

		//Parameters for Execution
		public int BatchSize { get; set; }
		public int MaxRetries { get; set; }
		public BackoffStrategy Backoff { get; set; }
		public bool DeleteOnSuccessfulRelay { get; set; }
		public int StoragePollingDelay { get; set; }
	}
}	



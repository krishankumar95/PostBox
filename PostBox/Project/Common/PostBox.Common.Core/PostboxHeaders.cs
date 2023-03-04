using System;
namespace PostBox.Common.Core
{
	public enum PostboxHeaders
	{
		/// <summary>
		/// Tags the Relayer Broker connection to a message ; enabling a message to be condiationally sent to a particular instance of broker if multiple broker instances are avalible
		/// </summary>
		CONNECTION_TAG
	}
}


using System;
using PostBox.Outbound.Relayer.Interface.Models;

namespace PostBox.Outbound.Relayer.Interface
{
	public interface IPostboxOutboundRelayer
	{
		Task ExecuteAsync();
	}
}


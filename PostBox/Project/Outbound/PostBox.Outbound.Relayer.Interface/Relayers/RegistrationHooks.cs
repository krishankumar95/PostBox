using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace PostBox.Outbound.Relayer.Interface.Relayers
{
	public static class RegistrationHooks
	{
		public static IServiceCollection Register(IServiceCollection serviceCollection)
		{
			serviceCollection.AddMediatR(typeof(RabbitMqOutboundRelayer));
            return serviceCollection;
		}
	}
}


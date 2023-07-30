using System;
using MediatR;
using PostBox.Common.Core.Notifications;
using PostBox.Outbound.Relayer.Interface.Models;

namespace PostBox.Outbound.Relayer.Interface
{
	public interface IPostboxOutboundRelayer : INotificationHandler<MessageIngestedNotification>
    {
		Task ExecuteAsync();
	}
}


using System;
using MediatR;

namespace PostBox.Common.Core.Notifications
{
	public class MessageIngestedNotification:INotification
	{
        public string MessageId { get; set; }

        public MessageIngestedNotification(string messageId)
		{
			MessageId = messageId;
		}
	}
}


using System;
namespace PostBox.Common.Core
{
	public class DeliveryParameters
	{
        public string ConnectionTag { get; set; }
        public MessagingEntityType EntityType { get; set; }
        public string EntityName { get; set; }

        public DeliveryParameters()
        {

        }

        public DeliveryParameters(MessagingEntityType entityType,string entityName)
        {
            EntityName = entityName;
            EntityType = entityType;
        }

    }
}


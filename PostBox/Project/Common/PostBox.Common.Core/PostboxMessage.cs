namespace PostBox.Common.Core
{
    public class PostboxMessage
    {

        public string Id{ get; set; }

        public DeliveryStatus Status { get; set; }

        /// <summary>
        /// Contains the Seralised Message Content , Allows for Empty Content to Support Header Only Communctation Messages
        /// </summary>
        public byte[]? MessageBody { get; set; }


        /// <summary>
        /// Used by PostBox to pick and chose which broker ingestion interface to pick for publishing
        /// </summary>
        public BrokerType BrokerType { get; set; }

        /// <summary>
        /// Contains the necessary parameters for routing and delivery , can vary across brokers
        /// </summary>
        //Dictionary<string, string> DeliveryAndRoutingParameters { get; set; } = new Dictionary<string, string>();
        public DeliveryParameters? DeliveryParameters { get; set; }

        /// <summary>
        /// Headers which are tied to the chosen broker, can vary across brokers
        /// </summary>
        public Dictionary<string, Object>? BrokerSpecificHeaders { get; set; } 

        /// <summary>
        /// Headers which are additionaly supplied by the publisher
        /// </summary>
        public Dictionary<string, Object>? CustomHeaders { get; set; }

        /// <summary>
        /// Headers for PostBox functionality
        /// </summary>
        public Dictionary<PostboxHeaders, Object>? PostboxHeaders { get; set; } 
    }
}

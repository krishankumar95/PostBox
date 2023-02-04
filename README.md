# PostBox

## A post-box for your Messaging Queue.

### a) Outbound PostBox
Holds outgoing messages from a producer till their eventual pickup and delivery to the Messaging Queue.

    1. Provides a buffer to fallback and keeps the asyc system functioning during intermittent failures.
    2. Historic record keeping and replay of events for supporting various patterns like Event Sourcing. (Configurable)
    
### b) Inbound PostBox 
Holds incoming messages from Messaging Queue just before their deilvery to consumer.

    1. Idempotency enforcement for the consumer.
    2. Historic record keeping and replay of events for the consumer. (Configurable)

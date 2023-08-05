public class MessageBase {
    public Guid MessageId { get; private set; }

    public MessageBase()
    {
        MessageId = Guid.NewGuid();        
    }

}
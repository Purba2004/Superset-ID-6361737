using Confluent.Kafka;

public class Consumer
{
    public void StartConsuming(string topic)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "chat-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe(topic);

        Console.WriteLine("Listening for messages...");
        while (true)
        {
            var cr = consumer.Consume();
            Console.WriteLine($"Received: {cr.Message.Value}");
        }
    }
}

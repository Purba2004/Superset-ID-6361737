using Confluent.Kafka;

public class Producer
{
    public async Task SendMessage(string topic, string user, string message)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        using var producer = new ProducerBuilder<Null, string>(config).Build();

        var fullMessage = $"{user}: {message}";
        await producer.ProduceAsync(topic, new Message<Null, string> { Value = fullMessage });

        Console.WriteLine($"Sent: {fullMessage}");
    }
}

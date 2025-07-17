internal class Program
{
    static async Task Main(string[] args)
    {
        var producer = new Producer();
        var consumer = new Consumer();
        var topic = "chat-topic";

        Console.Write("Enter username: ");
        string user = Console.ReadLine();

        Task.Run(() => consumer.StartConsuming(topic));

        while (true)
        {
            string msg = Console.ReadLine();
            await producer.SendMessage(topic, user, msg);
        }
    }
}

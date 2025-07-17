using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkaWinFormsChatApp
{
    public partial class Form1 : Form
    {
        private const string bootstrapServers = "localhost:9092";
        private const string topic = "chat-topic";
        private IProducer<Null, string> _producer;
        private CancellationTokenSource _cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            InitKafkaProducer();
            StartKafkaConsumer();
        }

        private void InitKafkaProducer()
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
                txtChat.AppendText($"Me: {message}\r\n");
                txtMessage.Clear();
            }
        }

        private void StartKafkaConsumer()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() =>
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = bootstrapServers,
                    GroupId = Guid.NewGuid().ToString(),
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumer.Subscribe(topic);

                    try
                    {
                        while (!_cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            try
                            {
                                var consumeResult = consumer.Consume(_cancellationTokenSource.Token);
                                Invoke((MethodInvoker)(() =>
                                {
                                    txtChat.AppendText($"User: {consumeResult.Message.Value}\r\n");
                                }));
                            }
                            catch (ConsumeException ex)
                            {
                                MessageBox.Show($"Consume error: {ex.Error.Reason}");
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                    }
                }
            }, _cancellationTokenSource.Token);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cancellationTokenSource.Cancel();
            _producer.Dispose();
        }
    }
}

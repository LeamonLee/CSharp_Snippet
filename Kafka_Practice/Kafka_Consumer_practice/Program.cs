using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka_Consumer_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Test().Wait();
        }

        static async Task Test()
        {
            var _config = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                //BootstrapServers = "localhost:9092",
                BootstrapServers = "kafka-1",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            Console.WriteLine(1);
            using var c = new ConsumerBuilder<Ignore, string>(_config).Build();
            Console.WriteLine(2);
            c.Subscribe("order");
            Console.WriteLine(3);

            // Because Consume is a blocking call, we want to capture Ctrl+C and use a cancellation token to get out of our while loop and close the consumer gracefully.
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    // Consume a message from the test topic. Pass in a cancellation token so we can break out of our loop when Ctrl+C is pressed
                    var cr = c.Consume(cts.Token);
                    Console.WriteLine($"Consumed message '{cr.Message.Value}' from topic {cr.Topic}, partition {cr.Partition}, offset {cr.Offset}");
                    int nValue = 0;
                    if (Int32.TryParse(cr.Message.Value, out nValue))
                    {
                        Console.WriteLine($"Divided Value: {100 / nValue}");   
                    };

                    // Do something interesting with the message you consumed
                }
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                c.Close();
            }
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}

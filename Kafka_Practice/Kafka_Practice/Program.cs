using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka_Producer_Practice
{
    class Program
    {
        private static bool keepRunning = true;
        static void Main(string[] args)
        {
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                Program.keepRunning = false;
            };
            Test().Wait();
            Console.WriteLine("exited gracefully");
        }

        static async Task Test()
        {
            var _config = new ProducerConfig { BootstrapServers = "kafka-1" };
            var employee = new Employee { Id = 1, Name = "Leamon" };
            string serializedEmployee = JsonConvert.SerializeObject(employee);

            var i = 0;
            while (Program.keepRunning)
            {
                Console.WriteLine(1);
                // Construct the message to send (generic type must match what was used above when creating the producer)
                var message = new Message<Null, string>
                {
                    Value = $"Message #{++i}"
                    //Value = serializedEmployee
                };

                // Create a producer that can be used to send messages to kafka that have no key and a value of type string 
                // using var p = new ProducerBuilder<Null, string>(_config).Build();
                using (var producer = new ProducerBuilder<Null, string>(_config).Build())
                {
                    // Send the message to our test topic in Kafka                
                    var dr = await producer.ProduceAsync("order", message);
                    producer.Flush(TimeSpan.FromSeconds(10));
                    Console.WriteLine($"Produced message '{dr.Value}' to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}");
                }

                Thread.Sleep(1000);
            }
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}

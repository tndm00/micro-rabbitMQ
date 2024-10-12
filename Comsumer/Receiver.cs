using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var conection = factory.CreateConnection();
using var channel = conection.CreateModel();
channel.QueueDeclare("BasicTest", false, false, false, null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) => 
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");
};

channel.BasicConsume("BasicTest", true, consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
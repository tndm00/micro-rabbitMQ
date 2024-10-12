using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("BasicTest", false, false, false, null);
var message = "Hello World!";
var body = Encoding.UTF8.GetBytes(message);
channel.BasicPublish("", "BasicTest", null, body);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
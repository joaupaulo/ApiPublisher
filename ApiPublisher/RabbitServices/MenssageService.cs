using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPublisher.Entidades;
using RabbitMQ.Client;

namespace ApiPublisher.RabbitServices
{
    public class MenssageService : IMenssageService
    {
        public void ConnectMensage(Produtos produto)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = System.Text.Json.JsonSerializer.Serialize(produto);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}

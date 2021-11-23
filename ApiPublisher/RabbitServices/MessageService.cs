using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiPublisher.Entidades;
using RabbitMQ.Client;

namespace ApiPublisher.RabbitServices
{
    public class MenssageService : IMenssageService
    {

        //"por uma consulta no banco pra poder fazer a filtragem se já existe no banco ou não"




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
                
            }

          

        }
    }
}

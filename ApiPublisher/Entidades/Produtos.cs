using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiPublisher.Entidades
{
    public class Produtos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int ProdutoId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Descrption { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int QuantVendidos { get; set; }

    }
}

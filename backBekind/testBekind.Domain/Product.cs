using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace testBekind.Domain
{
    public class Product
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("price")]
        public decimal Price { get; set; }


        [BsonElement("description")]
        public string Description { get; set; }



        [BsonElement("category")]
        public string Category { get; set; } = string.Empty;


    }
}

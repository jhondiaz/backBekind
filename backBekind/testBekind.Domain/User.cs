using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace testBekind.Domain
{
    public class User
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;


        [BsonElement("pwd")]
        public string Pwd { get; set; } = string.Empty;

        [BsonElement("rol")]
        public string Rol { get; set; }





    }
}

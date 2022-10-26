using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FuelAPI.models
{
    [BsonIgnoreExtraElements]
    public class FuelUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("active")]
        public bool Active { get; set; }

    }
}

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
        [BsonElement("location")]
        public string Location { get; set; } = string.Empty;
        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [BsonElement("start")]
        public string Start { get; set; }

        [BsonElement("end")]
        public string End { get; set; }

    }
}

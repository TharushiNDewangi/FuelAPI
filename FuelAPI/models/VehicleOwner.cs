using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FuelAPI.models
{
    [BsonIgnoreExtraElements]
    public class VehicleOwner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("neareststation")]
        public string Neareststation { get; set; } = string.Empty;
        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [BsonElement("arrivaltime")]
        public string Arrivaltime { get; set; }

        [BsonElement("departtime")]
        public string Departtime { get; set; }
    }
}

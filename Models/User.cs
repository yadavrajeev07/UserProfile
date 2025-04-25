using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace userprofileapp.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Country")]
        public string Country { get; set; }

        [BsonElement("State")]
        public string State { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Quotifier.Models
{
    public class Quote
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Contributor { get; set; }

        public string Content { get; set; }
    }
}

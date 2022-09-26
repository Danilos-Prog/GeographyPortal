using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GeographyPortal.Models
{
    public class Test
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public Guid UserId { get; set; }

        public IEnumerable<string>? Exercises { get; set; }
    }
}

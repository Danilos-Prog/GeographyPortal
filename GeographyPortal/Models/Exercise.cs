using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GeographyPortal.Models
{
    public class Exercise
    {
        [BsonId]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Description { get; set; }

    }
}

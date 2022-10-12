using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace GeographyPortal.Models
{
    /// <summary>
    /// Exercise Entity
    /// </summary>
    public class Exercise
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        public string Description { get; set; }

        public ICollection<string> answers { get; set; }

        public int rightAnswer { get; set; }

    }
}

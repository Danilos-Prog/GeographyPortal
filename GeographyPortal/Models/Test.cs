﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace GeographyPortal.Models
{
    public class Test
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public IEnumerable<Guid>? Exercises { get; set; }
    }
}

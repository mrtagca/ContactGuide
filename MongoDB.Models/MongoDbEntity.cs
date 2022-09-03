using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MongoDB.Models
{
    public abstract class MongoDbEntity : IEntity<string>
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //[BsonId]
        //[BsonElement(Order = 0)]
        [JsonIgnore] //id nin insert edilememesi için bu attribute u kullanıyoruz. (System.Text.Json.Serialization)
        public string Id { get; set; }

        //[BsonRepresentation(BsonType.DateTime)]
        //[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        //[BsonElement(Order = 101)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(3);
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(3);
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace InterviewCrusherAdmin.DataAbstraction
{
  public class IDatabaseEntityRepresentation
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public bool Deleted { get; set; } = false;

  }
}

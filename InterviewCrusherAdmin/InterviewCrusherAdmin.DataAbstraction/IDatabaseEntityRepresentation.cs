using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace InterviewCrusherAdmin.DataAbstraction
{
  public interface IDatabaseEntityRepresentation
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } 

    public bool Deleted { get; set; } 

  }
}

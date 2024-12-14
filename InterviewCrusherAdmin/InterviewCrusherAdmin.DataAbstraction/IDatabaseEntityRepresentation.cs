using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace InterviewCrusherAdmin.DataAbstraction
{
  public abstract class IDatabaseEntityRepresentation
  {
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; }

    public bool Deleted { get; set; }

    public IDatabaseEntityRepresentation()
    {
      Deleted = false;
      Id = ObjectId.GenerateNewId().ToString();
    }
  }
}

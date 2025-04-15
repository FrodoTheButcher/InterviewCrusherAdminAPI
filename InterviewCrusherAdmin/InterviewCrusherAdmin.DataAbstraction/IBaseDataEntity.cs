using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InterviewCrusherAdmin.DataAbstraction
{
  public abstract class IBaseDataEntity : IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public bool Deleted { get; set; } = false;

  }
}

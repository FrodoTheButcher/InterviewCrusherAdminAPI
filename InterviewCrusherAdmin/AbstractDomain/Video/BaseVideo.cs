using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InterviewCrusher.AbstractDomain.Video
{
  public class BaseVideo : BaseVideoDto
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id { get; set; } = string.Empty;
    public bool Deleted { get; set; }
  }
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusher.AbstractDomain.Video
{
  public class BaseVideoDto : IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public float VideoLength { get; set; }

    public string Description { get; set; } = string.Empty;
    [BsonRepresentation(BsonType.ObjectId)]
    public string ParentId { get; set; } = string.Empty;
    public ushort ExerciseNumber { get; set; } = ushort.MinValue;
  }
}

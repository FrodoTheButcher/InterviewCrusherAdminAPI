using InterviewCrusherAdmin.DataAbstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InterviewCrusherAdmin.CommonDomain.VideosDto
{
  public class VideoRepresentationDto : IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public float VideoLength { get; set; }

    public string Description { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.ObjectId)]
    public string ParentId { get; set; } = string.Empty;
  }
}

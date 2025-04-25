using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusher.AbstractDomain.Chapter
{
  public class BaseChapterDto : IDtoRepresentation
  {
    [BsonRepresentation(BsonType.ObjectId)]
    public string ParentId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SourceLink { get; set; } = string.Empty;
    public string SourceCode { get; set; } = string.Empty;
    public ushort ExerciseNumber { get; set; }

  }
}

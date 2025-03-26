using InterviewCrusherAdmin.DataAbstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.Domain.Chapter
{
  public class ChapterRepresentation : IDatabaseEntityRepresentation, IAutoIncrementEntity
  {
    [BsonRepresentation(BsonType.ObjectId)]
    public string ParentId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public ushort ExerciseNumber { get; set; }
    public string Description { get; set; } = string.Empty;
    public string SourceLink { get; set; } = string.Empty;
    public string SourceCode { get; set; } = string.Empty;
  }
}

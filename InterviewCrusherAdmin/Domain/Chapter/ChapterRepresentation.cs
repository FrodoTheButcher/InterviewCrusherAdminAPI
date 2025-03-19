using InterviewCrusherAdmin.DataAbstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;

namespace InterviewCrusherAdmin.Domain.Chapter
{
  public class ChapterRepresentation : IDatabaseEntityRepresentation
  {
    [BsonRepresentation(BsonType.ObjectId)]
    public string TemplateId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public ushort NumberChapter { get; set; }
    public string Description { get; set; } = string.Empty;
    public string SourceLink { get; set; } = string.Empty;
    public string SourceCode { get; set; } = string.Empty;

  }
}
